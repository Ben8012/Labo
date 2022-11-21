using BLL.Interfaces;
using labo.Tools;
using Labo.Models;
using Labo.Models.DTO.UserAPI;
using Labo.Models.Forms;
using Labo.Models.Forms.User;
using Labo.Mappers;
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

        private readonly IUserBll _userBll;
        private readonly ILogger _logger;
        private readonly ITokenManager _token;

        public UserController(ILogger<UserController> logger, IUserBll userBll, ITokenManager token)
        {
            _userBll = userBll;
            _logger = logger;
            _token = token;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_userBll.GetAll().Select(u => u.ToUser()));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin" , ErrorMessage = ex.Message });
            }
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_userBll.GetById(id)?.ToUser());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage =  ex.Message });
            }
        }

        

        [HttpPost("Insert")]
        public IActionResult Insert(AddUserForm form)
        {
            if(!ModelState.IsValid) return BadRequest(new {Message = "ModelState insert est invalide"});

            form.Password = BCrypt.Net.BCrypt.HashPassword(form.Password);
            try
            {
                return Ok(_userBll.Insert(form.ToAddUserFromBll())?.ToUser());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'insertion a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }

        }


        [HttpPut("Update")]
        public IActionResult Update(UpdateUserForm form)
        {
            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState update est invalide" });
            try
            {
                return Ok(_userBll.Update(form.ToUpdateUserFormBll())?.ToUser());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la modification a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
                   
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_userBll.Delete(id));

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la suppression a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginForm form)
        {
            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState Login est invalide" });
            try
            {
                User? user = _userBll.Login(form.ToLoginFormBll()).ToUser();

                if (user is null)
                {
                    return BadRequest(new { Message = "L'utilisateur n'a pas été trouvé " });
                }
                UserWithToken userWithToken = new UserWithToken()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Birthdate = user.Birthdate,
                    CreatedAt = user.CreatedAt,
                    UpdatedAt = user.UpdatedAt,
                    Token = _token.GenerateJWTUser(user)
                };

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "le login a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

    }
}
