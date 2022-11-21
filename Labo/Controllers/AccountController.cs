﻿using BLL.Interfaces;
using Labo.Models.Forms.Account;
using Labo.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPost("Desactivate")]
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


        [HttpPost("Reactivate")]
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

        [HttpPost("Delete/{id}")]
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
