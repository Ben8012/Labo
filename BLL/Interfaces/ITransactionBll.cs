using BLL.Models.DTO.Transaction;
using BLL.Models.Forms.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITransactionBll
    {
        TransactionBll? GetById(int id);
        IEnumerable<TransactionBll> GetByAccountDebitId(int id);
        IEnumerable<TransactionBll> GetByAccountCreditId(int id);
        TransactionBll? Insert(AddTransactionFormBll form);
        TransactionBll? Update(UpdateTransactionFormBll form);
        int? Delete(int id);

    }
}
