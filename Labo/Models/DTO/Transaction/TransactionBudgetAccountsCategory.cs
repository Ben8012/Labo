using Labo.Models.DTO.AccountAPI;
using Labo.Models.DTO.BudgetAPI;
using Labo.Models.DTO.CategoryAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Labo.Models.DTO.TransactionAPI
{
    public class TransactionBudgetAccountsCategory
    {
        public int Id { get; set; }
        public double TotalAmount { get; set; }
        public DateTime ExecutionDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool IsActive { get; set; }
        public Budget Budget { get; set; }
        public Account AccountDebit { get; set; }
        public Account AccountCredit { get; set; }
        public Category Category { get; set; }
    }
}
