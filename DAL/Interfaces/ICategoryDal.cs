using DAL.Models.DTO.Category;
using DAL.Models.Forms.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICategoryDal
    {
        int Delete(int id);
        int Desactivate(int id);
        int Reactivate(int id);
        IEnumerable<CategoryDal> GetAll();
        CategoryDal Insert(AddCategoryFormDal addForm);
        CategoryDal Update(UpdateCategoryFormDal updatecategoryFormDal);
        CategoryDal GetById(int id);
    }
}
