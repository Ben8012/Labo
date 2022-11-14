using Labo.Models;
using System.Data.Common;

namespace Labo.Models.Mappers
{
    internal static class DbDataReaderExtensions
    {
        internal static User ToUser(this DbDataReader reader)
        {
            return new User()
            {
                Id = (int)reader["Id"],
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
                Birthdate = (DateTime)reader["Birthdate"],
                Email = (string)reader["Email"],
                CreatedAt = (DateTime)reader["CreatedAt"],
            };
        }


        internal static Transaction ToTransaction(this DbDataReader reader)
        {
            return new Transaction()
            {
                Id = (int)reader["Id"],
                UserId = (int)reader["UserId"],
                AccountId = (int)reader["AccountId"],
                CategorieId = (int)reader["CategorieId"],
                Amout = (double)reader["Amout"]
               
            };
        }
    }
}
