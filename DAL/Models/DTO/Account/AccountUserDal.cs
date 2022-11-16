using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTO.Account
{
    public class AccountUserDal
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string AccountType { get; set; }
        public string ReceiverName { get; set; }
        public string? Communication { get; set; }
        public bool IsOwner { get; set; }

        public int UserId { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Email { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
