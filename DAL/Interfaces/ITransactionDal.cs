using DAL.Models.DTO.Transaction;
using DAL.Models.Forms.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITransactionDal
    {
        TransactionDal? GetById(int id);
        IEnumerable<TransactionDal> GetByAccountDebitId(int id);
        IEnumerable<TransactionDal> GetByAccountCreditId(int id);
        TransactionDal? Insert(AddTransactionFormDal form);
        TransactionDal? Update(UpdateTransactionFormDal form);
        int? Delete(int id);


    }
}
