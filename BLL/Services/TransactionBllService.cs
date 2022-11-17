using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models.DTO.Transaction;
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

        public IEnumerable<AllInfoCreditUserBll> GetAllInfoCreditByUser(int Id)
        {
            return _transactionDal.GetAllInfoCreditByUser(Id).Select(a => a.ToGetAllInfoCreditByUserDal());
        }
    }
}
