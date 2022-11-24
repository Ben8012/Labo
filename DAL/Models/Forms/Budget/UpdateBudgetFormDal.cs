using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Forms.Budget
{
    public class UpdateBudgetFormDal
    {
        public int Id { get; set; }
        public int PediodByMonth { get; set; }
        public string Label { get; set; }

        public int UserId { get; set; }
    }
}
