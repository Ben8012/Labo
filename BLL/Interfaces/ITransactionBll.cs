using BLL.Models.DTO.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITransactionBll
    {
        IEnumerable<TransactionBudgetAccountsCategoryBll> GetTransactionByAccountDebit(int id);
        IEnumerable<TransactionBudgetAccountsCategoryBll> GetTransactionByAccountCredit(int id);
    }
}
