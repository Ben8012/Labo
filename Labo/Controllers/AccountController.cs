using BLL.Interfaces;
using Labo.Models.Forms.Account;
using Labo.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Labo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Auth")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountBll _accountBll;

        public AccountController(IAccountBll accountBll)
        {
            _accountBll = accountBll;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_accountBll.GetAll().Select(a => a.ToAccount()));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_accountBll.GetById(id).ToAccount());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpPost("Insert")]
        public IActionResult Insert(AddAccountForm addAccountForm)
        {
            try
            {
                return Ok(_accountBll.Insert(addAccountForm.ToAddAccountFromBll()));
            }
            catch(Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpPatch("Desactivate")]
        public IActionResult Desactivate(int id)
        {
            try
            {
                return Ok(_accountBll.Desactivate(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }


        [HttpPatch("Reactivate")]
        public IActionResult Reactivate(int id)
        {
            try
            {
                return Ok(_accountBll.Reactivate(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_accountBll.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(UpdateAccountForm updateAccountForm)
        {
            try
            {
                return Ok(_accountBll.Update(updateAccountForm.ToUpdateAccountFormBll()).ToAccount());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }


    }
}
