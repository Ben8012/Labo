namespace Labo.Models.DTO.TransactionAPI
{
    public class Transaction
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
