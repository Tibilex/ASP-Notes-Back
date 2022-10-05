using Microsoft.AspNetCore.Mvc;
using QueryLibrary.Models;
using QueryLibrary.Repositories;

namespace NoteCards_ASP.NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArchiveController : Controller
    {
        [HttpGet("Get All Notes")]
        public async Task<ActionResult> GetAll()
        {
            await Task.Delay(1);
            return Ok(ArchiveRepository.GetAll());
        }


        [HttpGet("Get Notes by Owner {token}, {owner}")]
        public async Task<ActionResult> Get(string token, string owner)
        {
            await Task.Delay(1);
            if (UserRepository.UserValidCheck(owner, token))
            {
                List<Archive> listNotes = new();
                foreach (var item in ArchiveRepository.GetAll())
                {
                    if (item.Owner == owner) listNotes.Add(item);
                }
                return Ok(listNotes);
            }
            else return NoContent();
        }
    }
}
