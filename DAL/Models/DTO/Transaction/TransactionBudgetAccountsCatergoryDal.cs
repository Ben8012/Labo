using DAL.Models.DTO.Account;
using DAL.Models.DTO.Budget;
using DAL.Models.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTO.Transaction
{
    public class TransactionBudgetAccountsCategoryDal
    {
        public int Id { get; set; }
        public double TotalAmount { get; set; }
        public DateTime ExecutionDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool IsActive { get; set; }
        public BudgetDal Budget { get; set; }

        public AccountDal AccountDebit { get; set; }
        public AccountDal AccountCredit { get; set; }

        public CategoryDal Category { get; set; }

    }
}
