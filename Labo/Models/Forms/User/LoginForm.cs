using System.ComponentModel.DataAnnotations;

namespace Labo.Models.Forms.User
{
    public class LoginForm
    {
        [Required]
        [EmailAddress]
        [MinLength(1)]
        [MaxLength(384)]
        public string Email { get; set; }
      

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
