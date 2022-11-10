namespace Labo.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int AccountId { get; set; }

        public int CategorieId { get; set; }

        public double Amout { get; set; }
    }
}
