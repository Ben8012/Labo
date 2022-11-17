using DAL.Interfaces;
using DAL.Mappers;
using DAL.Models.DTO.Transaction;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace DAL.Services
{
    public class TransactionDalService : ITransactionDal
    {
        private readonly Connection _connection;
        private readonly ILogger _logger;

        public TransactionDalService(ILogger<TransactionDalService> logger, Connection connection)
        {
            _connection = connection;
            _logger = logger;
        }

        public IEnumerable<AllInfoCreditUserDal> GetAllInfoCreditByUser(int Id)
        {
            Command command = new Command("SELECT [User].FirstName, [User].LastName, [Budget].[Label] as BudgetLabel, [Budget].PeriodByMonth as BudgetPeriode , [Transaction].TotalAmout as TotalAmount, [Transaction].ExecutionDate, [Account].Number, [Account].ReceiverName, [Account].Communication FROM [User] JOIN Budget ON[User].Id = Budget.UserId JOIN[Transaction] ON[Transaction].BudgetId = [Budget].Id JOIN[Account] ON[Account].Id = [Transaction].AccountCreditId WHERE[User].Id = 1; ", false);
            command.AddParameter("id", Id);
            try
            {
               return _connection.ExecuteReader(command,c => c.ToAllInfosCreditUser()).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
    }
}
