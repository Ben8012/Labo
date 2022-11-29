using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Forms.Transaction
{
    public class UpdateTransactionFormBll
    {
        public int Id { get; set; }
        public double TotalAmount { get; set; }
        public DateTime ExecutionDate { get; set; }
        public int BudgetId { get; set; }
        public int AccountDebitId { get; set; }
        public int AccountCreditId { get; set; }
        public int CategoryId { get; set; }
        public string? Communication { get; set; }
    }
}
