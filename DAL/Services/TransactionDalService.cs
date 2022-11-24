using DAL.Interfaces;
using DAL.Mappers;
using DAL.Models;
using DAL.Models.DTO.Account;
using DAL.Models.DTO.Budget;
using DAL.Models.DTO.Category;
using DAL.Models.DTO.Transaction;
using DAL.Models.Forms.Transaction;
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


        public TransactionDal GetById(int id)
        {
            Command cmd = new Command("SELECT * FROM [Transaction] WHERE Id = @Id", false);
            cmd.AddParameter("Id", id);
            try
            {
                TransactionDal? transaction = _connection.ExecuteReader(cmd, t => t.ToTransactionDal()).SingleOrDefault();
                if (transaction == null) throw new Exception("Id invalide");
                return transaction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TransactionDal> GetByAccountDebitId(int id)
        {
            Command cmd = new Command("SELECT * FROM [Transaction] WHERE AccountDebitId = @Id",false);
            cmd.AddParameter("Id", id);
            try
            {
                IEnumerable<TransactionDal> transactions =_connection.ExecuteReader(cmd, t => t.ToTransactionDal());
                if (transactions == null) throw new Exception("Id invalide");
                return transactions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TransactionDal> GetByAccountCreditId(int id)
        {
            Command cmd = new Command("SELECT * FROM [Transaction] WHERE AccountCreditId = @Id", false);
            cmd.AddParameter("Id", id);
            try
            {
                IEnumerable<TransactionDal> transactions = _connection.ExecuteReader(cmd, t => t.ToTransactionDal());
                if (transactions == null) throw new Exception("Id invalide");
                return transactions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public TransactionDal? Insert(AddTransactionFormDal form)
        {
            Command command = new Command("INSERT INTO [Transaction]( TotalAmount, ExecutionDate, CreatedAt, IsActive, BudgetId, AccountDebitId, AccountCreditId ,Communication ) OUTPUT inserted.id VALUES (@TotalAmount, @ExecutionDate, GETDATE() , 1 , @BudgetId , @AccountDebitId, @AccountCreditId , @Communication)  ", false);
            command.AddParameter("TotalAmount", form.TotalAmount);
            command.AddParameter("ExecutionDate", form.ExecutionDate);
            command.AddParameter("BudgetId", form.BudgetId);
            command.AddParameter("AccountDebitId", form.AccountDebitId);
            command.AddParameter("AccountCreditId", form.AccountCreditId);
            command.AddParameter("Communication", form.Communication == "" ? DBNull.Value : form.Communication);

            try
            {
                int? id = (int?)_connection.ExecuteScalar(command); 
                if (id.HasValue)
                {
                    TransactionDal? transaction = GetById(id.Value);
                    if (transaction == null) throw new Exception("Id invalide");
                    return transaction;
                }
                else
                {
                    throw new Exception("probleme de recuperation de l'id lors de l'insertion");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public TransactionDal? Update(UpdateTransactionFormDal form)
        {
            Command command = new Command("UPDATE [Transaction] SET TotalAmount = @TotalAmount, ExecutionDate = @ExecutionDate, BudgetId =@BudgetId, AccountDebitId = @AccountDebitId, AccountCreditId = @AccountCreditId, Communication = @Communication , UpdatedAt = GETDATE() OUTPUT inserted.id WHERE Id =@Id", false);
            command.AddParameter("Id", form.Id);
            command.AddParameter("TotalAmount", form.TotalAmount);
            command.AddParameter("ExecutionDate", form.ExecutionDate);
            command.AddParameter("BudgetId", form.BudgetId);
            command.AddParameter("AccountCreditId", form.AccountCreditId);
            command.AddParameter("AccountDebitId", form.AccountDebitId);
            command.AddParameter("Communication", form.Communication == "" ? DBNull.Value : form.Communication);

            try
            {
                int? resultid = (int?)_connection.ExecuteScalar(command);
                if (!resultid.HasValue) throw new Exception("probleme de recuperation de l'id lors de la mise a jour");
                TransactionDal? transaction = GetById(resultid.Value);
                if (transaction is null) throw new Exception("probleme de recuperation de l'utilisateur lors de la mise a jour");
                return transaction;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public int? Delete(int id)
        {
            Command command = new Command("DELETE FROM [Transaction] WHERE Id=@Id", false);
            command.AddParameter("Id", id);
            try
            {
                int nbLigne =_connection.ExecuteNonQuery(command);
                if (nbLigne != 1) throw new Exception("erreur lors de la suppression");
                return nbLigne;  

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }


    }
}


//SELECT
//[Transaction].Id AS T_Id,
//[Transaction].TotalAmount As T_TotalAmount,
//[Transaction].CreatedAt AS T_CreatedAt,
//[Transaction].UpdatedAt AS T_UpdateAt,
//[Transaction].IsActive AS T_IsActive,
//[Transaction].ExecutionDate AS T_ExecutionDate,
//[Transaction].Communication AS T_Communication,
//[Transaction].BudgetId AS T_BudgetId,
//[Transaction].AccountDebitId AS T_AccountDebitId,
//[Transaction].AccountCreditId AS T_AccountCreditId,

//AD.Id AS A_Id,
//AD.Number AS A_Number,
//AD.ReceiverName AS A_ReceiverName,
//AD.AccountType AS A_AccountType,
//AD.IsOwner AS A_IsOwner,
//AD.IsActive AS A_IsActive,
//AD.UserId AS A_UserId,

//AC.Id AS A_Id,
//AC.Number AS A_Number,
//AC.ReceiverName AS A_ReceiverName,
//AC.AccountType AS A_AccountType,
//AC.IsOwner AS A_IsOwner,
//AC.IsActive AS A_IsActive,
//AC.UserId AS A_UserId,

//UC.Id AS UC_Id,
//UC.LastName AS UC_LastName ,
//UC.FirstName AS UC_FirstName ,
//UC.Email AS UC_Email ,
//UC.Birthdate AS UC_Birthdate ,
//UC.CreatedAt AS UC_CreatedAt ,
//UC.UpdatedAt AS UC_UpdatedAt,

//UD.Id AS UD_Id,
//UD.LastName AS UD_LastName ,
//UD.FirstName AS UD_FirstName ,
//UD.Email AS UD_Email ,
//UD.Birthdate AS UD_Birthdate ,
//UD.CreatedAt AS UD_CreatedAt ,
//UD.UpdatedAt AS UD_UpdatedAt,

//[Budget].Id As B_Id,
//[Budget].PeriodByMonth AS B_PeriodByMonth,
//[Budget].[Label] AS B_Label,
//[Budget].UpdatedAt AS B_UpdatedAt,
//[Budget].CreatedAt AS B_CreatedAt,
//[Budget].IsActive AS B_IsActive,
//[Budget].UserId AS B_UserID,
//[Budget_Category].MaxAmount AS B_C_MaxAmount,

//[Category].[Id] AS C_Id,
//[Category].[Label] AS C_Label,
//[Category].CreatedAt AS C_CreatedAt,
//[Category].UpdatedAt AS C_UpdatedAt,
//[Category].IsActive AS C_IsActive

//FROM[Transaction]
//JOIN Account AS AD ON [Transaction].AccountDebitId = AD.Id
//JOIN[User] AS UD ON AD.[UserId] = UD.Id
//JOIN Account AS AC ON [Transaction].AccountCreditId = AC.Id
//JOIN[User] AS UC ON AC.[UserId] = UC.Id
//JOIN[Budget] ON[Transaction].BudgetId = [Budget].Id
//JOIN[Budget_Category] ON[Transaction].Id = [Budget_Category].BudgetId
//JOIN[Category] ON[Category].id = [Budget_Category].CategoryId

//WHERE[Account].Id = 1;