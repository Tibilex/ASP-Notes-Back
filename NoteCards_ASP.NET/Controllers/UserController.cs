using Microsoft.AspNetCore.Mvc;
using QueryLibrary.Models;
using QueryLibrary.Repositories;

namespace NoteCards_ASP.NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAllUsers()
        {
            await Task.Delay(1);
            return Ok(UserRepository.GetAll());
        }

        [HttpGet("Get {id}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            await Task.Delay(1);
            return Ok(UserRepository.GetUserById(id));
        }

        [HttpPut("Add User {name}, {password}")]
        public string Insert(string name, string password)
        {
            string token = CreateNewToken();
            UserRepository.AddUser(new User()
            {
                Name = name,
                Password = BCrypt.Net.BCrypt.HashPassword(password),
                Token = token
            });
            return token;
        }

        [HttpGet("Login User {token}, {name}, {password}")]
        public bool Login(string token, string name, string password)
        {
            if (UserRepository.UserValidCheck(name, token))
            {
                if (UserRepository.PasswordValidCheck(name, password)) return true;
                else return false;
            }
            else return false;
        }

        [HttpDelete("Delete User {id}")]
        public bool Delete(int id)
        {
            return UserRepository.DeleteUser(id);
        }

        // Create new Token
        private static string CreateNewToken()
        {
            string token;
            while (true)
            {
                token = RandomStringGenerator();
                if (!UserRepository.UserTokenValidCheck(token)) break;
            }
            return token;
        }

        // Create random string for Token
        private static string RandomStringGenerator()
        {
            string template = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            string token = "";

            for (int i = 0; i < 16; i++)
            {
                token += template[new Random().Next(0, template.Length - 1)];
            }
            return token;
        }
    }
}
