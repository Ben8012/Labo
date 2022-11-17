using DAL.Interfaces;
using DAL.Mappers;
using DAL.Models;
using DAL.Models.DTO.Account;
using DAL.Models.Forms.Account;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace DAL.Services
{
    public class AccountDalService : IAccountDal
    {
        private readonly Connection _connection;
        private readonly ILogger _logger;

        public AccountDalService(ILogger<AccountDalService> logger, Connection connection)
        {
            _connection = connection;
            _logger = logger;
        }

        public int Delete(int id)
        {
            int nbligne;
            Command command = new Command("DELETE FROM [Account] WHERE Id = @Id", false);
            command.AddParameter("id", id);
            try
            {
                nbligne = _connection.ExecuteNonQuery(command);
                if (nbligne != 0) return -1;
                return nbligne;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Desactivate(int id)
        {
            Command command = new Command("UPDATE [Account] SET IsActive = 0 WHERE @Id= Id", false);
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
            Command command = new Command("UPDATE [Account] SET IsActive = 1 WHERE @Id= Id", false);
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

        public List<AccountDal> GetAll()
        {
            Command command = new Command("SELECT Account.Id, Number, AccountType, ReceiverName, Communication, IsOwner, UserId, LastName, FirstName, Email, Birthdate, CreatedAt, UpdatedAt FROM [Account] JOIN [USER] ON [User].Id = [Account].UserId;", false);
            try
            {
                IEnumerable <AccountUserDal> accounts = _connection.ExecuteReader(command, dr => dr.ToAccountUserDal());
                List<AccountDal> accountsDal = new List<AccountDal>();
                foreach (AccountUserDal account in accounts)
                {
                    accountsDal.Add(new AccountDal()
                    {
                        Id = account.Id,
                        Number = account.Number,
                        AccountType = account.AccountType,
                        ReceiverName = account.ReceiverName,
                        Communication = account.Communication,
                        IsOwner = account.IsOwner,
                        User = new UserDal()
                        {
                            Id = account.UserId,
                            FirstName = account.FirstName,
                            LastName = account.LastName,
                            Email = account.Email,
                            Birthdate = account.Birthdate,
                            CreatedAt = account.CreatedAt,
                            UpdatedAt = account.UpdatedAt,
                        }
                    });
                }
                return accountsDal;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public AccountDal Insert(AddAccountFormDal addAccountFormDal)
        {
            Command command = new Command("INSERT INTO [Account](Number, AccountType, ReceiverName, Communication, IsOwner, UserId,IsActive ) OUTPUT inserted.id VALUES (@Number, @AccountType, @ReceiverName, @Communication, @IsOwner, @UserId, @IsActive)", false);
            command.AddParameter("Number", addAccountFormDal.Number);
            command.AddParameter("AccountType", addAccountFormDal.AccountType);
            command.AddParameter("ReceiverName", addAccountFormDal.ReceiverName);
            command.AddParameter("Communication", addAccountFormDal.Communication);
            command.AddParameter("IsOwner", addAccountFormDal.IsOwner);
            command.AddParameter("UserId", addAccountFormDal.UserId);
            command.AddParameter("IsActive", 1);

            try
            {
                int? id = (int?)_connection.ExecuteScalar(command);
                if (!id.HasValue) throw new Exception("probleme ! l'insertion dans la db a echoué");
                AccountDal? newAccount = GetAccountById(id.Value);
                if (newAccount is null) throw new Exception("probleme ! ce compte n'existe pas");
                return newAccount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      

        public AccountDal Update(UpdateAccountFormDal updateAccountFormDal)
        {
            Command command = new Command("SP_UpdateAccount", true);
            command.AddParameter("Number", updateAccountFormDal.Number);
            command.AddParameter("AccountType", updateAccountFormDal.AccountType);
            command.AddParameter("ReceiverName", updateAccountFormDal.ReceiverName);
            command.AddParameter("Communication", updateAccountFormDal.Communication);
            command.AddParameter("UserId", updateAccountFormDal.UserId);
            command.AddParameter("Id", updateAccountFormDal.Id);
            command.AddParameter("IsOwner", updateAccountFormDal.IsOwner);

            try
            {
               int? resultid = (int?)_connection.ExecuteScalar(command);
                if (!resultid.HasValue) throw new Exception("probleme de recuperation de l'id lors de la mise a jour");
                AccountDal? account = GetAccountById(resultid.Value);
                if (account is null) throw new Exception("probleme de recuperation de l'utilisateur lors de la mise a jour");
                return account;
           
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private AccountDal GetAccountById(int id)
        {
            Command command = new Command("SELECT Account.Id, Number, AccountType, ReceiverName, Communication, IsOwner, UserId, LastName, FirstName, Email, Birthdate, CreatedAt, UpdatedAt FROM [Account] JOIN [USER] ON [User].Id = [Account].UserId WHERE Account.Id = @Id; ", false);
            command.AddParameter("Id", id);
            try
            {
                AccountUserDal? account = _connection.ExecuteReader(command, dr => dr.ToAccountUserDal()).SingleOrDefault();
                return new AccountDal()
                {
                    Id = account.Id,
                    Number = account.Number,
                    AccountType = account.AccountType,
                    ReceiverName = account.ReceiverName,
                    Communication = account.Communication,
                    IsOwner = account.IsOwner,
                    User = new UserDal()
                    {
                        Id = account.UserId,
                        FirstName = account.FirstName,
                        LastName = account.LastName,
                        Email = account.Email,
                        Birthdate = account.Birthdate,
                        CreatedAt = account.CreatedAt,
                        UpdatedAt = account.UpdatedAt,
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
