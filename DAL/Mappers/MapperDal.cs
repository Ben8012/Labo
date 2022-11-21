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


        internal static TransactionDal ToTransaction(this DbDataReader reader)
        {
            return new TransactionDal()
            {
                T_Id = (int)reader["T_Id"],
                T_TotalAmount = (double)reader["T_TotalAmount"],
                T_ExecutionDate = (DateTime)reader["T_ExecutionDate"],
                T_CreatedAt = (DateTime)reader["T_CreatedAt"],
                T_UpdateAt = reader["T_UpdateAt"] is DBNull ? null : (DateTime)reader["T_UpdateAt"],
                T_IsActive = (bool)reader["T_IsActive"],
                T_BudgetId = (int)reader["T_BudgetId"],
                T_AccountDebitId = (int)reader["T_AccountDebitId"],
                T_AccountCreditId = (int)reader["T_AccountCreditId"],
                A_Id = (int)reader["A_Id"],
                A_Number = (string)reader["A_Number"],
                A_ReceiverName = (string)reader["A_ReceiverName"],
                A_AccountType = (string)reader["A_AccountType"],
                A_Communication = reader["A_Communication"] is DBNull ? null : (string)reader["A_Communication"],
                A_IsOwner = (bool)reader["A_IsOwner"],
                A_IsActive = (bool)reader["A_IsActive"],
                A_UserId = (int)reader["A_UserId"],
                B_Id = (int)reader["B_Id"],
                B_Label = (string)reader["B_Label"],
                B_PeriodByMonth = (int)reader["B_PeriodByMonth"],
                B_UpdatedAt = reader["B_UpdatedAt"] is DBNull ? null : (DateTime)reader["B_UpdatedAt"],
                B_CreatedAt = (DateTime)reader["B_CreatedAt"],
                B_IsActive = (bool)reader["B_IsActive"],
                B_UserID = (int)reader["B_UserID"],
                B_C_MaxAmount = (double)reader["B_C_MaxAmount"],
                C_Label = (string)reader["C_Label"],
                C_CreatedAt = (DateTime)reader["C_CreatedAt"],
                C_UpdatedAt = reader["C_UpdatedAt"] is DBNull ? null : (DateTime)reader["C_UpdatedAt"],
                C_IsActive = (bool)reader["C_IsActive"]
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

