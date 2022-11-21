using BLL.Interfaces;
using Labo.Models;
using Labo.Models.Forms;
using Labo.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tools;

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

        [HttpGet("GetTransactionByAccountDebit/{id}")]
        public IActionResult GetAllTransactionByAccountDebit(int id)
        {
            try
            {
                return Ok(_transactionBll.GetTransactionByAccountDebit(id).Select(t=>t.ToTransaction()));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }


        [HttpGet("GetTransactionByAccountCredit/{id}")]
        public IActionResult GetTransactionByAccountCredit(int id)
        {
            try
            {
                return Ok(_transactionBll.GetTransactionByAccountCredit(id).Select(t => t.ToTransaction()));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }


    }
}
