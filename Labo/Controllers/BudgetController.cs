using BLL.Interfaces;
using Labo.Mappers;
using Labo.Models.Forms.Budget;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetBll _budgetBll;

        public BudgetController(IBudgetBll budgetBll)
        {
            _budgetBll = budgetBll;
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_budgetBll.GetById(id).ToBudget());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_budgetBll.GetAll().Select(b => b.ToBudget()));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }


        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_budgetBll.Delete(id));
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
                return Ok(_budgetBll.Desactivate(id));
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
                return Ok(_budgetBll.Reactivate(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }


        [HttpPost("Insert")]
        public IActionResult Insert(AddBudgetForm addForm)
        {
            try
            {
                return Ok(_budgetBll.Insert(addForm.ToAddBudgetFromBll()).ToBudget());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(UpdateBudgetForm updateBudgetForm)
        {
            try
            {
                return Ok(_budgetBll.Update(updateBudgetForm.ToUpdateBudgetFromBll()).ToBudget());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }
       
    }
}
