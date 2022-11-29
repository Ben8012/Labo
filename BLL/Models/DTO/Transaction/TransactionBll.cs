using BLL.Models.DTO.Account;
using BLL.Models.DTO.Budget;
using BLL.Models.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.DTO.Transaction
{
    public class TransactionBll
    {
        public int Id { get; set; }
        public double TotalAmount { get; set; }
        public DateTime ExecutionDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool IsActive { get; set; }
        public int BudgetId { get; set; }
        public int AccountDebitId { get; set; }
        public int AccountCreditId { get; set; }
        public int CategoryId { get; set; }
        public string? Communication { get; set; }
    }
}
