using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTO.Budget
{
    public class BudgetDal
    {
        public int Id { get; set; } 
        public int PediodByMonth { get; set; }
        public string Label { get; set; }
        public DateTime? UdpateAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public UserDal User { get; set; }
    }
}
