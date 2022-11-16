using System.ComponentModel.DataAnnotations;

namespace Labo.Models.Forms.Transaction
{
    public class AddTransationForm
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int AccountId { get; set; }
        [Required]
        public int CategorieId { get; set; }
        [Required]
        public double Amout { get; set; }
    }
}
