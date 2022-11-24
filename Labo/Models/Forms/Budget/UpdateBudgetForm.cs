namespace Labo.Models.Forms.Budget
{
    public class UpdateBudgetForm
    {
        public int Id { get; set; }
        public int PediodByMonth { get; set; }
        public string Label { get; set; }

        public int UserId { get; set; }
    }
}
