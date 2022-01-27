using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SushiSite.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        public bool CashSettlement { get; set; } = false;
        public bool NonCashCalculation { get; set; } = true;
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public bool IsAddedToCart { get; set; }
    }
}
