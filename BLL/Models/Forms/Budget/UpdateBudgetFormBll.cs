using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Forms.Budget
{
    public class UpdateBudgetFormBll
    {
        public int Id { get; set; }
        public int PediodByMonth { get; set; }
        public string Label { get; set; }

        public int UserId { get; set; }
    }
}
