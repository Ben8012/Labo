


using Labo.Models.DTO.UserAPI;

namespace Labo.Models.DTO.BudgetAPI
{
    public class Budget
    {
        public int Id { get; set; }
        public int PediodByMonth { get; set; }
        public string Label { get; set; }
        public DateTime? UdpateAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
    }
}
