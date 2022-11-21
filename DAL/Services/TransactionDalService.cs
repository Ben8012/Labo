using DAL.Interfaces;
using DAL.Mappers;
using DAL.Models;
using DAL.Models.DTO.Account;
using DAL.Models.DTO.Budget;
using DAL.Models.DTO.Category;
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

        private UserDal? GetUserById(int id)
        {
            Command command = new Command("SELECT Id, LastName, FirstName, Email, Birthdate, CreatedAt, UpdatedAt FROM [User] WHERE Id = @Id;", false);
            command.AddParameter("Id", id);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToUserDal()).SingleOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public List<TransactionBudgetAccountsCategoryDal> GetTransactionByAccountDebit(int id)
        {
            Command command = new Command(@"SELECT [Transaction].Id AS T_Id,
                                            [Transaction].TotalAmount As T_TotalAmount,
                                            [Transaction].CreatedAt AS T_CreatedAt,
                                            [Transaction].UpdatedAt AS T_UpdateAt,
                                            [Transaction].IsActive AS T_IsActive,
                                            [Transaction].ExecutionDate AS T_ExecutionDate,
                                            [Transaction].BudgetId AS T_BudgetId,
                                            [Transaction].AccountDebitId AS T_AccountDebitId,
                                            [Transaction].AccountCreditId AS T_AccountCreditId,
                                            [Account].Id AS A_Id, 
                                            [Account].Number AS A_Number,
                                            [Account].ReceiverName AS A_ReceiverName,
                                            [Account].AccountType AS A_AccountType,
                                            [Account].Communication AS A_Communication,
                                            [Account].IsOwner AS A_IsOwner,
                                            [Account].IsActive AS A_IsActive,
                                            [Account].UserId AS A_UserId,
                                            [Budget].Id As B_Id,
                                            [Budget].PeriodByMonth AS B_PeriodByMonth,
                                            [Budget].[Label] AS B_Label,
                                            [Budget].UpdatedAt AS B_UpdatedAt,
                                            [Budget].CreatedAt AS B_CreatedAt,
                                            [Budget].IsActive AS B_IsActive,
                                            [Budget].UserId AS B_UserID,
                                            [Budget_Category].MaxAmount AS B_C_MaxAmount,
                                            [Category].[Id] AS C_Id,
                                            [Category].[Label] AS C_Label,
                                            [Category].CreatedAt AS C_CreatedAt,
                                            [Category].UpdatedAt AS C_UpdatedAt,
                                            [Category].IsActive AS C_IsActive
                                            FROM[Transaction] 
                                            JOIN Account ON [Transaction].AccountDebitId = [Account].Id
                                            JOIN[Budget] ON [Transaction].BudgetId = [Budget].Id
                                            JOIN[Budget_Category] ON[Transaction].Id = [Budget_Category].BudgetId
                                            JOIN[Category] ON [Category].id = [Budget_Category].CategoryId
                                            WHERE [Account].Id = @Id", false); ;
            command.AddParameter("id", id);

            try
            {
                IEnumerable<TransactionDal> transactions = _connection.ExecuteReader(command, dr => dr.ToTransaction());
                List<TransactionBudgetAccountsCategoryDal> listTransactions = new List<TransactionBudgetAccountsCategoryDal>();
                foreach (TransactionDal transaction in transactions)
                {
                    listTransactions.Add(new TransactionBudgetAccountsCategoryDal()
                    {
                        Id = transaction.T_Id,
                        TotalAmount = transaction.T_TotalAmount,
                        ExecutionDate = transaction.T_ExecutionDate,
                        CreatedAt = transaction.T_CreatedAt,
                        UpdateAt = transaction.T_UpdateAt,
                        IsActive = transaction.T_IsActive,
                        Budget = new BudgetDal()
                        {
                            Id = transaction.B_Id,
                            PediodByMonth = transaction.B_PeriodByMonth,
                            Label = transaction.B_Label,
                            UdpateAt = transaction.B_UpdatedAt,
                            CreatedAt = transaction.B_CreatedAt,
                            User = GetUserById(transaction.B_UserID),

                        },

                        AccountDebit = new AccountDal()
                        {
                            Id = transaction.A_Id,
                            Number = transaction.A_Number,
                            AccountType = transaction.A_AccountType,
                            ReceiverName = transaction.A_ReceiverName,
                            Communication = transaction.A_Communication,
                            IsOwner = transaction.A_IsOwner,
                            IsAcive = transaction.A_IsActive,
                            User = GetUserById(transaction.A_UserId),
                        },

                        Category = new CategoryDal()
                        {
                            Id = transaction.C_Id,
                            MaxAmount = transaction.B_C_MaxAmount,
                            Label = transaction.C_Label,
                            CreatedAt = transaction.C_CreatedAt,
                            UpdatedAt = transaction.C_UpdatedAt,
                            IsActive = transaction.C_IsActive
                        }
                    });
                }
                return listTransactions;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }




        public List<TransactionBudgetAccountsCategoryDal> GetTransactionByAccountCredit(int id)
        {
            Command command = new Command(@"SELECT [Transaction].Id AS T_Id,
                                            [Transaction].TotalAmount As T_TotalAmount,
                                            [Transaction].CreatedAt AS T_CreatedAt,
                                            [Transaction].UpdatedAt AS T_UpdateAt,
                                            [Transaction].IsActive AS T_IsActive,
                                            [Transaction].ExecutionDate AS T_ExecutionDate,
                                            [Transaction].BudgetId AS T_BudgetId,
                                            [Transaction].AccountDebitId AS T_AccountDebitId,
                                            [Transaction].AccountCreditId AS T_AccountCreditId,
                                            [Account].Id AS A_Id, 
                                            [Account].Number AS A_Number,
                                            [Account].ReceiverName AS A_ReceiverName,
                                            [Account].AccountType AS A_AccountType,
                                            [Account].Communication AS A_Communication,
                                            [Account].IsOwner AS A_IsOwner,
                                            [Account].IsActive AS A_IsActive,
                                            [Account].UserId AS A_UserId,
                                            [Budget].Id As B_Id,
                                            [Budget].PeriodByMonth AS B_PeriodByMonth,
                                            [Budget].[Label] AS B_Label,
                                            [Budget].UpdatedAt AS B_UpdatedAt,
                                            [Budget].CreatedAt AS B_CreatedAt,
                                            [Budget].IsActive AS B_IsActive,
                                            [Budget].UserId AS B_UserID,
                                            [Budget_Category].MaxAmount AS B_C_MaxAmount,
                                            [Category].[Id] AS C_Id,
                                            [Category].[Label] AS C_Label,
                                            [Category].CreatedAt AS C_CreatedAt,
                                            [Category].UpdatedAt AS C_UpdatedAt,
                                            [Category].IsActive AS C_IsActive
                                            FROM[Transaction] 
                                            JOIN Account ON [Transaction].AccountCreditId = [Account].Id
                                            JOIN[Budget] ON [Transaction].BudgetId = [Budget].Id
                                            JOIN[Budget_Category] ON[Transaction].Id = [Budget_Category].BudgetId
                                            JOIN[Category] ON [Category].id = [Budget_Category].CategoryId
                                            WHERE [Account].Id = @Id", false); ;
            command.AddParameter("id", id);

            try
            {
                IEnumerable<TransactionDal> transactions = _connection.ExecuteReader(command, dr => dr.ToTransaction());
                List<TransactionBudgetAccountsCategoryDal> listTransactions = new List<TransactionBudgetAccountsCategoryDal>();


                foreach (TransactionDal transaction in transactions)
                {
                    listTransactions.Add(new TransactionBudgetAccountsCategoryDal()
                    {
                        Id = transaction.T_Id,
                        TotalAmount = transaction.T_TotalAmount,
                        ExecutionDate = transaction.T_ExecutionDate,
                        CreatedAt = transaction.T_CreatedAt,
                        UpdateAt = transaction.T_UpdateAt,
                        IsActive = transaction.T_IsActive,
                        Budget = new BudgetDal()
                        {
                            Id = transaction.B_Id,
                            PediodByMonth = transaction.B_PeriodByMonth,
                            Label = transaction.B_Label,
                            UdpateAt = transaction.B_UpdatedAt,
                            CreatedAt = transaction.B_CreatedAt,
                            User = GetUserById(transaction.B_UserID),

                        },

                        AccountDebit = new AccountDal()
                        {
                            Id = transaction.A_Id,
                            Number = transaction.A_Number,
                            AccountType = transaction.A_AccountType,
                            ReceiverName = transaction.A_ReceiverName,
                            Communication = transaction.A_Communication,
                            IsOwner = transaction.A_IsOwner,
                            IsAcive = transaction.A_IsActive,
                            User = GetUserById(transaction.A_UserId),
                        },

                        Category = new CategoryDal()
                        {
                            Id = transaction.C_Id,
                            MaxAmount = transaction.B_C_MaxAmount,
                            Label = transaction.C_Label,
                            CreatedAt = transaction.C_CreatedAt,
                            UpdatedAt = transaction.C_UpdatedAt,
                            IsActive = transaction.C_IsActive
                        }
                    });

                };
                return listTransactions;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
    }
}
