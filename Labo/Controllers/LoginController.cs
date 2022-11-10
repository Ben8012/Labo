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
            Command command = new Command("SELECT Id, LastName, FirstName, Email, Birthdate FROM [User] WHERE Email = @Email AND Passwd = @Password", false);
            command.AddParameter("Email", form.Email);
            command.AddParameter("Password", form.Password);

            try
            {
                User? user = _connection.ExecuteReader(command, dr => dr.ToUser()).SingleOrDefault();

                if (user == null)
                {
                    return BadRequest(new { Message = "Email ou mot de passe incorrect " });
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
