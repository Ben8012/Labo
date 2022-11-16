using DAL.Models;
using DAL.Models.DTO.Account;
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
    }
}
