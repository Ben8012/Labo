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
        private readonly MyTools _myTools;



        public TransactionDalService(ILogger<TransactionDalService> logger, Connection connection)
        {
            _connection = connection;
            _logger = logger;
            _myTools = new MyTools(connection);
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
                if (transactions.Count() == 0) throw new Exception("Id invalide");
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
                if (transactions.Count() == 0) throw new Exception("Id invalide");
                return transactions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public TransactionDal? Insert(AddTransactionFormDal form)
        {
            bool isBugdetIdOk = _myTools.IsForeignKeyValid("Budget", form.BudgetId);
            if (!isBugdetIdOk) throw new Exception("clée etrangere budgetId invalide");

            bool isAccountDebitIdOk = _myTools.IsForeignKeyValid("Account", form.AccountDebitId);
            if (!isAccountDebitIdOk) throw new Exception("clée etrangere AccountDebitId invalide");

            bool isAccountCreditIdOk = _myTools.IsForeignKeyValid("Account", form.AccountCreditId);
            if (!isAccountCreditIdOk) throw new Exception("clée etrangere AccountCreditId invalide");

            Command command = new Command("INSERT INTO [Transaction]( TotalAmount, ExecutionDate, CreatedAt, IsActive, BudgetId, AccountDebitId, AccountCreditId ,Communication ) OUTPUT inserted.id VALUES (@TotalAmount, @ExecutionDate, GETDATE() , 1 , @BudgetId , @AccountDebitId, @AccountCreditId , @Communication)  ", false);
            command.AddParameter("TotalAmount", form.TotalAmount);
            command.AddParameter("ExecutionDate", form.ExecutionDate);
            command.AddParameter("BudgetId", form.BudgetId);
            command.AddParameter("AccountDebitId", form.AccountDebitId);
            command.AddParameter("AccountCreditId", form.AccountCreditId);
            command.AddParameter("Communication", form.Communication == "" ? DBNull.Value : form.Communication);

            int? id;
            TransactionDal? transaction;
            try
            {
                id = (int?)_connection.ExecuteScalar(command); 
                if (id.HasValue)
                {
                    transaction = GetById(id.Value);
                    if (transaction == null) throw new Exception("Id invalide");
                  
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

            Command cmd2 = new Command("INSERT INTO [Transaction_Category](AmoutDetail, CategoryId, TransactionId) OUTPUT inserted.id VALUES(@AmoutDetail, @CategoryId, @TransactionId)", false);
            cmd2.AddParameter("AmoutDetail", 0);
            cmd2.AddParameter("CategoryId", form.CategoryId );
            cmd2.AddParameter("TransactionId", id);

            int? insterdedId_T_C;
            try
            {
               insterdedId_T_C =  (int?)_connection.ExecuteScalar(cmd2);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Command cmd3 = new Command("INSERT INTO [Budget_Category](MaxAmount, CategoryId, BudgetId) OUTPUT inserted.id VALUES(@MaxAmount, @CategoryId, @BudgetId)", false);
            cmd3.AddParameter("MaxAmount", 0);
            cmd3.AddParameter("CategoryId", form.CategoryId);
            cmd3.AddParameter("BudgetId", form.BudgetId);

            int? insertedId_B_C;
            try
            {
                insertedId_B_C =(int?)_connection.ExecuteScalar(cmd3);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return transaction;

        }



        public TransactionDal? Update(UpdateTransactionFormDal form)
        {
           

            bool isBugdetIdOk = _myTools.IsForeignKeyValid("Budget", form.BudgetId);
            if (!isBugdetIdOk) throw new Exception("clée etrangere budgetId invalide");

            bool isAccountDebitIdOk = _myTools.IsForeignKeyValid("Account", form.AccountDebitId);
            if (!isAccountDebitIdOk) throw new Exception("clée etrangere AccountDebitId invalide");

            bool isAccountCreditIdOk = _myTools.IsForeignKeyValid("Account", form.AccountCreditId);
            if (!isAccountCreditIdOk) throw new Exception("clée etrangere AccountCreditId invalide");

            Command command = new Command("UPDATE [Transaction] SET TotalAmount = @TotalAmount, ExecutionDate = @ExecutionDate, BudgetId =@BudgetId, AccountDebitId = @AccountDebitId, AccountCreditId = @AccountCreditId, Communication = @Communication , UpdatedAt = GETDATE() OUTPUT inserted.id WHERE Id =@Id", false);
            command.AddParameter("Id", form.Id);
            command.AddParameter("TotalAmount", form.TotalAmount);
            command.AddParameter("ExecutionDate", form.ExecutionDate);
            command.AddParameter("BudgetId", form.BudgetId);
            command.AddParameter("AccountCreditId", form.AccountCreditId);
            command.AddParameter("AccountDebitId", form.AccountDebitId);
            command.AddParameter("Communication", form.Communication == "" ? DBNull.Value : form.Communication);

            TransactionDal? transaction;
            try
            {
                int? resultid = (int?)_connection.ExecuteScalar(command);
                if (!resultid.HasValue) throw new Exception("probleme de recuperation de l'id lors de la mise a jour");
                transaction = GetById(resultid.Value);
                if (transaction is null) throw new Exception("probleme de recuperation de l'utilisateur lors de la mise a jour");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Command cmd2 = new Command("UPDATE [Transaction_Category] SET AmoutDetail = @AmoutDetail OUTPUT inserted.id WHERE TransactionId = @TransactionId AND CategoryId = @CategoryId", false);
            cmd2.AddParameter("AmoutDetail", 0);
            cmd2.AddParameter("CategoryId", form.CategoryId);
            cmd2.AddParameter("TransactionId",form.Id);

            int insterdedId_T_C;
            try
            {
                insterdedId_T_C = (int)_connection.ExecuteScalar(cmd2);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Command cmd3 = new Command("UPDATE [Budget_Category] SET MaxAmount = @MaxAmount OUTPUT inserted.id WHERE CategoryId= @CategoryId AND BudgetId = @BudgetId", false);
            cmd3.AddParameter("MaxAmount", 0);
            cmd3.AddParameter("CategoryId", form.CategoryId);
            cmd3.AddParameter("BudgetId", form.BudgetId);

            int insertedId_B_C;
            try
            {
                insertedId_B_C = (int)_connection.ExecuteScalar(cmd3);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return transaction;

        }


        public int? Delete(int id)
        {
            Command cmd2 = new Command("DELETE FROM [Transaction_Category] WHERE TransactionId = @TransactionId", false);
            cmd2.AddParameter("TransactionId", id);
            try
            {
                _connection.ExecuteNonQuery(cmd2);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Command command = new Command("DELETE FROM [Transaction] OUTPUT deleted.id WHERE Id=@Id", false);
            command.AddParameter("Id", id);

            int? deletedId;
            try
            {
                deletedId = (int?)_connection.ExecuteScalar(command);
                if (!deletedId.HasValue) throw new Exception("erreur lors de la suppression");
                return deletedId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }

          
        }

        public int Desactivate(int id)
        {
            Command command = new Command("UPDATE [Transaction] SET IsActive = 0 WHERE @Id= Id", false);
            command.AddParameter("id", id);

            int nbligne;
            try
            {
                nbligne = _connection.ExecuteNonQuery(command);
                if (nbligne != 1) return -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return nbligne;
        }

        public int Reactivate(int id)
        {
            Command command = new Command("UPDATE [Transaction] SET IsActive = 1 WHERE @Id= Id", false);
            command.AddParameter("id", id);

            int nbligne;
            try
            {
                nbligne = _connection.ExecuteNonQuery(command);
                if (nbligne != 1) return -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return nbligne;
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