using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Forms.Transaction
{
    public class UpdateTransactionFormDal
    {
        public int Id { get; set; }
        public double TotalAmount { get; set; }
        public DateTime ExecutionDate { get; set; }
        public int BudgetId { get; set; }
        public int AccountDebitId { get; set; }
        public int AccountCreditId { get; set; }
        public string? Communication { get; set; }
    }
}
