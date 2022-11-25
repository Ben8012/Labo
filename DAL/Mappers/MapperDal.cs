using DAL.Models;
using DAL.Models.DTO.Account;
using DAL.Models.DTO.Budget;
using DAL.Models.DTO.Category;
using DAL.Models.DTO.Transaction;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal static class MapperDal
    {
        internal static UserDal ToUserDal(this DbDataReader reader)
        {
            return new UserDal()
            {
                Id = (int)reader["Id"],
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
                Birthdate = (DateTime)reader["Birthdate"],
                Email = (string)reader["Email"],
                CreatedAt = (DateTime)reader["CreatedAt"],
                UpdatedAt = reader["UpdatedAt"] is DBNull ? null : (DateTime?)reader["UpdatedAt"],
            };
        }

        internal static AccountUserDal ToAccountUserDal(this DbDataReader reader)
        {
            return new AccountUserDal()
            {
                Id = (int)reader["Id"],
                Number = (string)reader["Number"],
                AccountType = (string)reader["AccountType"],
                ReceiverName = (string)reader["ReceiverName"],
                //Communication = reader["Communication"] is DBNull ? null : (string)reader["Communication"],
                IsOwner = (bool)reader["IsOwner"],
                UserId = (int)reader["UserId"] ,
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
                Birthdate = (DateTime)reader["Birthdate"],
                Email = (string)reader["Email"],
                CreatedAt = (DateTime)reader["CreatedAt"],
                UpdatedAt = reader["UpdatedAt"] is DBNull ? null : (DateTime?)reader["UpdatedAt"],
            };
        }


        internal static TransactionDal ToTransactionDal(this DbDataReader reader)
        {
            return new TransactionDal()
            {
                Id = (int)reader["Id"],
                TotalAmount = (double)reader["TotalAmount"],
                ExecutionDate = (DateTime)reader["ExecutionDate"],
                CreatedAt = (DateTime)reader["CreatedAt"],
                UpdateAt = reader["UpdatedAt"] is DBNull ? null : (DateTime)reader["UpdatedAt"],
                IsActive = (bool)reader["IsActive"],
                BudgetId = (int)reader["BudgetId"],
                AccountDebitId = (int)reader["AccountDebitId"],
                AccountCreditId = (int)reader["AccountCreditId"],
                Communication = reader["Communication"] is DBNull ? null : (string)reader["Communication"]
               
            };
         }

        internal static AccountDal ToAccountDal(this DbDataReader reader)
        {
            return new AccountDal()
            {
                Id = (int)reader["Id"],
                Number = (string)reader["Number"],
                AccountType = (string)reader["AccountType"],
                ReceiverName = (string)reader["ReceiverName"],
                //Communication = reader["Communication"] is DBNull ? null : (string)reader["Communication"],
                IsOwner = (bool)reader["IsOwner"],
               
            };
        }


        internal static BudgetDal ToBudgetDal(this DbDataReader reader)
        {
            return new BudgetDal()
            {
                Id = (int)reader["Id"],
                PediodByMonth = (int)reader["PeriodByMonth"],
                Label = (string)reader["Label"],
                UdpatedAt = reader["UpdatedAt"] is DBNull ? null : (DateTime)reader["UpdatedAt"],
                CreatedAt =  (DateTime)reader["CreatedAt"],
                UserId = (int)reader["UserId"],
                IsActive = (bool)reader["IsActive"]

            };
        }


        internal static CategoryDal ToCategoryDal(this DbDataReader reader)
        {
            return new CategoryDal()
            {
                Id = (int)reader["Id"],
                Label = (string)reader["Label"],
                UpdatedAt = reader["UpdatedAt"] is DBNull ? null : (DateTime)reader["UpdatedAt"],
                CreatedAt = (DateTime)reader["CreatedAt"],
                IsActive = (bool)reader["IsActive"]
            };
        }
    }
}

