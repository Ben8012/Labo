using Labo.Models.DTO.User;

namespace Labo.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string AccountType { get; set; }
        public string ReceiverName { get; set; }
        public string? Communication { get; set; }
        public bool IsOwner { get; set; }

        public User User { get; set; }
    }
}
