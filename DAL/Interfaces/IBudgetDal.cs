using DAL.Models.DTO.Budget;
using DAL.Models.Forms.Budget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBudgetDal
    {
        BudgetDal GetById(int id);
        int Delete(int id);
        int Desactivate(int id);
        int Reactivate(int id);
        IEnumerable<BudgetDal> GetAll();
        BudgetDal Insert(AddBudgetFormDal addForm);
        BudgetDal Update(UpdateBudgetFormDal updateBudgetFormDal);
    }
}
