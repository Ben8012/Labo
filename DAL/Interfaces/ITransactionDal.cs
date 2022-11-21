using DAL.Models.DTO.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITransactionDal
    {
        List<TransactionBudgetAccountsCategoryDal> GetTransactionByAccountDebit(int id);
        List<TransactionBudgetAccountsCategoryDal> GetTransactionByAccountCredit(int id);
    }
}
