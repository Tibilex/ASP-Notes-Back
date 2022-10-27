using Microsoft.AspNetCore.Mvc;
using QueryLibrary.Models.Admin;
using QueryLibrary.Models;

namespace NoteCards_ASP.NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private AdminWork work;

        [HttpGet("GetAll")]
        public IEnumerable<object> GetAll() => work.AdminRepository.GetAll();

        [HttpGet("GetId")]
        public object GetId(int id) => work.AdminRepository.Get(id);

        public AdminController()
        {
            work = new AdminWork();
        }

        [HttpPost("Add Note")]
        public object Add([FromForm] Note note)
        {
            return work.AdminRepository.Add(note);
        }

        [HttpDelete("Delete Note")]
        public ActionResult Delete(int id)
        {
            if (work.AdminRepository.Delete(id)) return Ok();
            else return NotFound();
        }
    }
}
