
using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models.DTO.Category;
using BLL.Models.Forms.Category;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryBllService : ICategoryBll
    {

        private readonly ILogger _logger;
        private readonly ICategoryDal _categoryDal;

        public CategoryBllService(ILogger<TransactionBllService> logger, ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
            _logger = logger;
        }
        public int Delete(int id)
        {
            return _categoryDal.Delete(id);
        }

        public int Desactivate(int id)
        {
            return _categoryDal.Desactivate(id);
        }

        public IEnumerable<CategoryBll> GetAll()
        {
            return _categoryDal.GetAll().Select(c => c.ToCategoryBll());
        }

        public CategoryBll GetById(int id)
        {
            return _categoryDal.GetById(id).ToCategoryBll();
        }

        public CategoryBll Insert(AddCategoryFormBll addForm)
        {
            return _categoryDal.Insert(addForm.ToAddCategoryFromDal()).ToCategoryBll();
        }

        public int Reactivate(int id)
        {
            return _categoryDal.Reactivate(id);
        }

        public CategoryBll Update(UpdateCategoryFormBll updatecategoryForm)
        {
            return _categoryDal.Update(updatecategoryForm.ToUpdateCategoryFromDal()).ToCategoryBll();
        }
    }
}
