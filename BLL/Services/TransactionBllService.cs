using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models.DTO.Transaction;
using BLL.Models.Forms.Transaction;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TransactionBllService :ITransactionBll
    {
        private readonly ILogger _logger;
        private readonly ITransactionDal _transactionDal;

        public TransactionBllService(ILogger<TransactionBllService> logger, ITransactionDal transactionDal)
        {
            _transactionDal = transactionDal;
            _logger = logger;
        }

        public int? Delete(int id)
        {
            return _transactionDal.Delete(id);
        }

        public IEnumerable<TransactionBll> GetByAccountCreditId(int id)
        {
            return _transactionDal.GetByAccountCreditId(id).Select(t => t.ToTransactionBll());
        }

        public IEnumerable<TransactionBll> GetByAccountDebitId(int id)
        {
            return _transactionDal.GetByAccountDebitId(id).Select(t => t.ToTransactionBll());
        }

        public TransactionBll GetById(int id)
        {
            return _transactionDal.GetById(id).ToTransactionBll();
        }

        public TransactionBll Insert(AddTransactionFormBll form)
        {
            return _transactionDal?.Insert(form.ToAddTransactionFromDal()).ToTransactionBll();
        }

        public TransactionBll Update(UpdateTransactionFormBll form)
        {
            return _transactionDal.Update(form.ToUpdateTransactionFromDal()).ToTransactionBll();
        }
    }
}
