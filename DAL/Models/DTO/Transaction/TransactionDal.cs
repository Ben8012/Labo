
using DAL.Models.DTO.Account;
using DAL.Models.DTO.Budget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTO.Transaction
{
    public class TransactionDal
    {
        public int T_Id { get; set; }
        public double T_TotalAmount { get; set; }
        public DateTime T_ExecutionDate { get; set; }
        public DateTime T_CreatedAt { get; set; }
        public DateTime? T_UpdateAt { get; set; }
        public bool T_IsActive { get; set; }
        public int T_BudgetId { get; set; }
        public int T_AccountDebitId { get; set; } 
        public int T_AccountCreditId { get; set; }
        public int A_Id { get; set; }
        public string A_Number { get; set; }
        public string A_ReceiverName { get; set; }
        public string A_AccountType { get; set; }
        public string? A_Communication { get; set; }
        public bool A_IsOwner { get; set; }
        public bool A_IsActive { get; set; }
        public int A_UserId { get; set; }
        public int B_Id { get; set; }
        public string B_Label { get; set; }
        public int B_PeriodByMonth { get; set; }
        public DateTime? B_UpdatedAt { get; set; }
        public DateTime B_CreatedAt { get; set; }
        public bool B_IsActive { get; set; }
        public int B_UserID { get; set; }
        public double B_C_MaxAmount { get; set; }
        public int C_Id { get; set; }
        public string C_Label { get; set; }
        public DateTime C_CreatedAt { get; set; }
        public DateTime? C_UpdatedAt { get; set; }
        public bool C_IsActive { get; set; }

    }
}
