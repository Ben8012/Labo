namespace Labo.Models.Forms.Account
{
    public class AddAccountForm
    {
        public string Number { get; set; }
        public string AccountType { get; set; }
        public string ReceiverName { get; set; }
        //public string? Communication { get; set; }
        public bool IsOwner { get; set; }
        public int UserId { get; set; }
    }
}
