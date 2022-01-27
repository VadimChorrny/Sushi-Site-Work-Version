using System.Collections.Generic;

namespace SushiSite.Models
{
    public class OrderSummaryMail
    {
        public IEnumerable<Food> Foods { get; set; }
        public int TotalPrice { get; set; }
        public string UserName { get; set; }
    }
}
