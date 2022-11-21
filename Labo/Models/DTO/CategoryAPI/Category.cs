namespace Labo.Models.DTO.CategoryAPI
{
    public class Category
    {
        public int Id { get; set; }
        public double MaxAmount { get; set; }
        public string Label { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
