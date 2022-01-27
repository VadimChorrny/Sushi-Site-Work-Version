using System.ComponentModel.DataAnnotations;

namespace SushiSite.Models
{
    public class Food
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public int Amount { get; set; }
        public string Image { get; set; } = "https://memepedia.ru/wp-content/uploads/2021/09/chupapi-munjanja-ne-budet-6-360x270.jpg";
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
