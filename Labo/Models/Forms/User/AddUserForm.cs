using System.ComponentModel.DataAnnotations;

namespace Labo.Models.Forms.User
{
    public class AddUserForm
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [EmailAddress]
        [MinLength(1)]
        [MaxLength(384)]
        public string Email { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
