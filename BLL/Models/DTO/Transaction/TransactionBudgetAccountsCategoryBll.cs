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
    public class TransactionBudgetAccountsCategoryBll
    {
        public int Id { get; set; }
        public double TotalAmount { get; set; }
        public DateTime ExecutionDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool IsActive { get; set; }
        public BudgetBll Budget { get; set; }

        public AccountBll AccountDebit { get; set; }
        public AccountBll AccountCredit { get; set; }

        public CategoryBll Category { get; set; }
    }
}
