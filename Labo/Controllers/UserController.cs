using Labo.Models;
using Labo.Models.Forms;
using Labo.Models.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using Tools;

namespace Labo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly Connection _connection;
        private readonly ILogger _logger;

        public UserController(ILogger<UserController> logger, Connection connection)
        {
            _connection = connection;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            Command command = new Command("SELECT Id, LastName, FirstName, Email, Birthdate, CreatedAt FROM [User];", false);

            try
            {
                return Ok(_connection.ExecuteReader(command, dr => dr.ToUser()).ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { Message = "Un probleme est survenu lors de la recuperation des données, contactez l'admin" });
            }
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            Command command = new Command("SELECT Id, LastName, FirstName, Email, Birthdate, CreatedAt FROM [User] WHERE Id = @Id;", false);
            command.AddParameter("Id", id);
            try
            {
                return Ok(_connection.ExecuteReader(command, dr => dr.ToUser()).SingleOrDefault());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        

        [HttpPost("Insert")]
        public IActionResult Insert(AddUserForm form)
        {

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(form.Password);

            Command command = new Command("SP_InsertUser", true);
            command.AddParameter("LastName", form.LastName);
            command.AddParameter("FirstName", form.FirstName);
            command.AddParameter("Email", form.Email);
            command.AddParameter("Birthdate", form.Birthdate);
            command.AddParameter("Password", passwordHash);

            int? id = (int?)_connection.ExecuteScalar(command); // recuperer l'id du contact inseré

            if (id.HasValue)
            {
                User? user = GetUserById(id.Value);
                return Ok(user);
            }
            else
            {
                return BadRequest(new { Message = "l'insertion a échoué" });
            }
        }


        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, UpdateUserForm form)
        {
         
            Command command = new Command($"SP_UpdateUser", true);
            command.AddParameter("Id", id);
            command.AddParameter("FirstName", form.FirstName);
            command.AddParameter("Email", form.Email);
            command.AddParameter("Birthdate", form.Birthdate);
            command.AddParameter("LastName", form.LastName);

            int? resultid = (int?)_connection.ExecuteScalar(command);

            if (!resultid.HasValue) return BadRequest(new { Message = "l'insertion a échoué" });
             
            User? newuser = GetUserById(resultid.Value);

            if(newuser is null ) return BadRequest(new { Message = "le nouvel utilisateur n'a pas été trouvé" });

            return Ok(newuser);
                   
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            Command command = new Command("DELETE FROM [User] WHERE Id=@Id", false);
            command.AddParameter("Id", id);
            try
            {
                return Ok(_connection.ExecuteNonQuery(command)); // renvois le nombre de ligne affectés

            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { Message = "Un probleme est survenu lors de la suppression, contactez l'admin" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { Message = "Un probleme est survenu, contactez l'admin" });
            }
        }


        private User? GetUserById(int id)
        {
            Command command = new Command("SELECT Id, LastName, FirstName, Email, Birthdate, CreatedAt FROM [User] WHERE Id = @Id;", false);
            command.AddParameter("Id", id);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToUser()).SingleOrDefault();
            }
            catch (Exception ex)
            {

                return null;
            }
        }


    }
}
