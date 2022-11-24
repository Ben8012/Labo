using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models.DTO.Budget;
using BLL.Models.Forms.Budget;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace BLL.Services
{
    public class BudgetBllService : IBudgetBll
    {

        private readonly IBudgetDal _bugdetDal;
        private readonly ILogger _logger;

        public BudgetBllService(ILogger<BudgetBllService> logger, IBudgetDal bugdetDal)
        {
            _bugdetDal = bugdetDal;
            _logger = logger;
        }
        public int Delete(int id)
        {
            return _bugdetDal.Delete(id) ;
        }

        public int Desactivate(int id)
        {
            return _bugdetDal.Desactivate(id) ;
        }

        public IEnumerable<BudgetBll> GetAll()
        {
            return _bugdetDal.GetAll().Select(b => b.ToBudgetBll());
        }

        public BudgetBll GetById(int id)
        {
            return _bugdetDal.GetById(id).ToBudgetBll() ;
        }

        public BudgetBll Insert(AddBudgetFormBll addForm)
        {
            return _bugdetDal.Insert(addForm.ToAddBudgetFromDal()).ToBudgetBll();
        }

        public int Reactivate(int id)
        {
            return _bugdetDal.Reactivate(id) ;
        }

        public BudgetBll Update(UpdateBudgetFormBll updateBudgetFormBll)
        {
            return _bugdetDal.Update(updateBudgetFormBll.ToUpdateBudgetFromDal()).ToBudgetBll();
        }
    }
}
