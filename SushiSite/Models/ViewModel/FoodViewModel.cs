using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace SushiSite.Models.ViewModel
{
    public class FoodViewModel
    {
        public Food Food { get; set; }
        public IEnumerable<SelectListItem> Category { get; set; }
    }
}
