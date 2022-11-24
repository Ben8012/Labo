using BLL.Interfaces;
using Labo.Mappers;
using Labo.Models.Forms.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryBll _categoryBll;

        public CategoryController(ICategoryBll categoryBll)
        {
            _categoryBll = categoryBll;
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_categoryBll.GetById(id).ToCategory());
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
                return Ok(_categoryBll.GetAll().Select(c => c.ToCategory()));
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
                return Ok(_categoryBll.Delete(id));
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
                return Ok(_categoryBll.Desactivate(id));
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
                return Ok(_categoryBll.Reactivate(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }


        [HttpPost("Insert")]
        public IActionResult Insert(AddCategoryForm addForm)
        {
            try
            {
                return Ok(_categoryBll.Insert(addForm.ToAddCategoryFromBll()).ToCategory());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(UpdateCategoryForm updateCategoryForm)
        {
            try
            {
                return Ok(_categoryBll.Update(updateCategoryForm.ToUpdateCategoryFromBll()).ToCategory());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }
    }
}
