using Labo.Models.Forms.Transaction;
using System.Transactions;

namespace Labo.Interfaces
{
    public interface ITransaction
    {
        Transaction? GetById(int id);
        IEnumerable<Transaction> GetByAccountDebitId(int id);
        IEnumerable<Transaction> GetByAccountCreditId(int id);
        Transaction? Insert(AddTransactionForm form);
        Transaction? Update(UpdateTransactionForm form);
        int? Delete(int id);
    }
}
