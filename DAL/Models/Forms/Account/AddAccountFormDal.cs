using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Forms.Account
{
    public class AddAccountFormDal
    {
        public string Number { get; set; }
        public string AccountType { get; set; }
        public string ReceiverName { get; set; }
        public string? Communication { get; set; }
        public bool IsOwner { get; set; }
        public int UserId { get; set; }
    }
}
