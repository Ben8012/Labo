using BLL.Interfaces;
using Labo.Models;
using Labo.Models.Forms;
using Labo.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tools;
using Labo.Models.Forms.Transaction;

namespace Labo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly ITransactionBll _transactionBll;
        private readonly ILogger _logger;

        public TransactionController(ILogger<TransactionController> logger, ITransactionBll transactionBll)
        {
            _transactionBll = transactionBll;
            _logger = logger;
        }

     
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_transactionBll.GetById(id).ToTransaction());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }


        [HttpGet("GetByAccountDebitId/{id}")]
        public IActionResult GetByAccountDebitId(int id)
        {
            try
            {
                return Ok(_transactionBll.GetByAccountDebitId(id).Select(t => t.ToTransaction()));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpGet("GetByAccountCreditId/{id}")]
        public IActionResult GetByAccountCreditId(int id)
        {
            try
            {
                return Ok(_transactionBll.GetByAccountCreditId(id).Select(t => t.ToTransaction()));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }


        [HttpPatch("Desactivate")]
        public IActionResult Desactivate(int id)
        {
            try
            {
                return Ok(_transactionBll.Desactivate(id));
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
                return Ok(_transactionBll.Reactivate(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpPost("Insert")]
        public IActionResult Insert(AddTransactionForm form)
        {
            try
            {
                return Ok(_transactionBll?.Insert(form.ToAddTransactionFromBll()).ToTransaction());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(UpdateTransactionForm form)
        {
            try
            {
                return Ok(_transactionBll?.Update(form.ToUpdateTransactionFromBll()).ToTransaction());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_transactionBll.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

    }
}
