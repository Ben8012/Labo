using DAL.Models;
using DAL.Models.DTO.Account;
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
                Communication = reader["Communication"] is DBNull ? null : (string)reader["Communication"],
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


        internal static AllInfoCreditUserDal ToAllInfosCreditUser(this DbDataReader reader)
        {
            return new AllInfoCreditUserDal()
            {
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
                ExecutionDate = (DateTime)reader["ExecutionDate"],
                BudgetLabel = (string)reader["BudgetLabel"],
                Communication = reader["Communication"] is DBNull ? null : (string?)reader["Communication"],
                BudgetPeriode = (int)reader["BudgetPeriode"],
                TotalAmount = (double)reader["TotalAmount"],
                Number =(string)reader["Number"],
                ReceiverName = (string)reader["Number"]
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
                Communication = reader["Communication"] is DBNull ? null : (string)reader["Communication"],
                IsOwner = (bool)reader["IsOwner"],
               
            };
        }
    }
}

