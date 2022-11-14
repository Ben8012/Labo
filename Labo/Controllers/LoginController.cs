using Labo.Models;
using Labo.Models.Forms;
using Labo.Models.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tools;

namespace Labo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly Connection _connection;
        private readonly ILogger _logger;

        public LoginController(ILogger<LoginController> logger, Connection connection)
        {
            _connection = connection;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            Command command = new Command("SELECT Password FROM [User] WHERE Email = @Email ", false);
            command.AddParameter("Email", form.Email);

            string? passwordHash = (string?)_connection.ExecuteScalar(command);

            if(passwordHash is null)  return BadRequest("L'email est invailde");

            bool verified = BCrypt.Net.BCrypt.Verify(form.Password, passwordHash);

            if (!verified) return BadRequest("Le mot de passe est invailde");
            
            Command command2 = new Command("SELECT Id, LastName, FirstName, Email, Birthdate,CreatedAt FROM [User] WHERE Email = @Email", false);
            command2.AddParameter("Email", form.Email);
         
            try
            {
                User? user = _connection.ExecuteReader(command2, dr => dr.ToUser()).SingleOrDefault();

                if (user is null)
                {
                    return BadRequest(new { Message = "L'utilisateur n'a pas été trouvé " });
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
