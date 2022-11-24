
using BLL.Models.DTO.Budget;
using BLL.Models.Forms.Budget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBudgetBll
    {
        BudgetBll GetById(int id);
        int Delete(int id);
        int Desactivate(int id);
        int Reactivate(int id);
        IEnumerable<BudgetBll> GetAll();
        BudgetBll Insert(AddBudgetFormBll addForm);
        BudgetBll Update(UpdateBudgetFormBll updateBudgetFormBll);
    }
}
