using Microsoft.AspNetCore.Mvc;
using QueryLibrary.Models;
using QueryLibrary.Repositories;

namespace NoteCards_ASP.NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : Controller
    {
       
        [HttpGet("Get All Notes {token}, {owner}")]
        public async Task<ActionResult> GetAll(string token, string owner)
        {
            await Task.Delay(1);
            if (UserRepository.UserValidCheck(owner, token))
            {
                List<Note> allNoteslist = new();
                foreach (var item in NoteRepository.GetAll())
                {
                    if (item.Owner == owner)
                    {
                        allNoteslist.Add(item);
                    }
                }
                return Ok(allNoteslist);
            }
            else
            { 
                return NoContent();
            }
        }

        
        [HttpGet("Get Note Id {token}, {owner}, {id}")]
        public async Task<ActionResult> Get(string token, string owner, int id)
        {
            await Task.Delay(1);
            if (UserRepository.UserValidCheck(owner, token))
            {
                Note note = NoteRepository.GetNoteToId(id);
                if (note != null && note.Owner == owner)
                {
                    return Ok(note);
                }
                else return NoContent();
            }
            else return NoContent();
        }


        [HttpGet("Get Notes by Add Time {token}, {owner}, {startTime}, {endTime}")]
        public async Task<ActionResult> Get(string token, string owner, DateTime startTime, DateTime endTime)
        {
            await Task.Delay(1);
            if (UserRepository.UserValidCheck(owner, token))
            {
                List<Note> allNoteslist = new();
                foreach (var item in NoteRepository.GetAll())
                {
                    if (item.Owner == owner && item.CreatedTime >= startTime && item.CreatedTime <= endTime) allNoteslist.Add(item);
                }
                return Ok(allNoteslist);
            }
            else return NoContent();
        }


        [HttpPut("Add Note {token}, {owner}, {title}, {text}")]
        public long Insert(string token, string owner, string title, string text)
        {
            if (UserRepository.UserValidCheck(owner, token))
            {
                return NoteRepository.AddNote(new Note() { Owner = owner, Label = title, Text = text, CreatedTime = DateTime.Now });
            }
            else return -1;
        }


        [HttpPut("Add Note to Archive {token}, {owner}, {id}")]
        public async Task<ActionResult> ArchiveNote(string token, string owner, int id)
        {
            await Task.Delay(1);
            if (UserRepository.UserValidCheck(owner, token))
            {
                Note note = NoteRepository.GetNoteToId(id);
                if (note != null && note.Owner == owner)
                {
                    Archive arhiveNote = new();
                    arhiveNote.Owner = note.Owner;
                    arhiveNote.Label = note.Label;
                    arhiveNote.Text = note.Text;
                    arhiveNote.AddToArchive = DateTime.Now;
                    ArchiveRepository.AddNoteToArchive(arhiveNote);
                    return Ok(NoteRepository.DeleteNote(id));
                }
                else return NoContent();
            }
            else return NoContent();
        }


        [HttpDelete("Delete Note {token}, {owner}, {id}")]
        public async Task<ActionResult> Delete(string token, string owner, int id)
        {
            await Task.Delay(1);
            if (UserRepository.UserValidCheck(owner, token))
            {
                Note note = NoteRepository.GetNoteToId(id);
                if (note != null && note.Owner == owner)
                {
                    return Ok(NoteRepository.DeleteNote(id));
                }
                else return NoContent();
            }
            else return NoContent();
        }
    }
}
