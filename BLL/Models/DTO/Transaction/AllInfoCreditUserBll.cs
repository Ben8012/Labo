using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.DTO.Transaction
{
    public class AllInfoCreditUserBll
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BudgetLabel { get; set; }
        public int BudgetPeriode { get; set; }
        public double TotalAmount { get; set; }
        public DateTime ExecutionDate { get; set; }
        public string Number { get; set; }
        public string ReceiverName { get; set; }
        public string? Communication { get; set; }
    }
}
