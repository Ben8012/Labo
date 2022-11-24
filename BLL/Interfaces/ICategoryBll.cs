using BLL.Models.DTO.Category;
using BLL.Models.Forms.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICategoryBll
    {
        int Delete(int id);
        int Desactivate(int id);
        int Reactivate(int id);
        IEnumerable<CategoryBll> GetAll();
        CategoryBll Insert(AddCategoryFormBll addForm);
        CategoryBll Update(UpdateCategoryFormBll updatecategoryForm);
        CategoryBll GetById(int id);
    }
}
