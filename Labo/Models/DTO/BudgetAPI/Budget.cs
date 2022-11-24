


using Labo.Models.DTO.UserAPI;

namespace Labo.Models.DTO.BudgetAPI
{
    public class Budget
    {
        public int Id { get; set; }
        public int PediodByMonth { get; set; }
        public string Label { get; set; }
        public DateTime? UdpatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
    }
}
