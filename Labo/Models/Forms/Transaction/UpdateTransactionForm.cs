using System.ComponentModel.DataAnnotations;

namespace Labo.Models.Forms.Transaction
{
    public class UpdateTransactionForm
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public double TotalAmount { get; set; }
        [Required]
        public DateTime ExecutionDate { get; set; }
        [Required]
        public int BudgetId { get; set; }
        [Required]
        public int AccountDebitId { get; set; }
        [Required]
        public int AccountCreditId { get; set; }
        public string? Communication { get; set; }
    }
}
