using BLL.Models.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.DTO.Budget
{
    public class BudgetBll
    {
        public int Id { get; set; }
        public int PediodByMonth { get; set; }
        public string Label { get; set; }
        public DateTime? UdpatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
