using BLL.Interfaces;
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
    public class TransactionController : ControllerBase
    {

        private readonly ITransactionBll _transactionBll;
        private readonly ILogger _logger;

        public TransactionController(ILogger<TransactionController> logger, ITransactionBll transactionBll)
        {
            _transactionBll = transactionBll;
            _logger = logger;
        }

        [HttpGet("GetAllInfoCreditByUser")]
        public IActionResult GetAllInfoCreditByUser(int Id)
        {
            try
            {
                return Ok(_transactionBll.GetAllInfoCreditByUser(Id).Select(a => a.ToGetAllInfoCreditByUserDal()));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

            
        }
}
