using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SushiSite.Data;
using SushiSite.Models;
using SushiSite.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace SushiSite.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Orders.Include(nameof(Order.Food)));
        }
        public IActionResult AddOrder()
        {
            IEnumerable<SelectListItem> foods = _context.Foods.Select(e => new SelectListItem()
            { Text = e.Title, Value = e.Id.ToString() });
            ViewBag.FoodList = foods;

            return View();
        }
        [HttpPost]
        public IActionResult AddOrder(Order newOrder)
        {
            if (!ModelState.IsValid) return View();
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0) return NotFound();
            var orderToRemove = _context.Orders.Find(id);
            if (orderToRemove == null) return NotFound();
            _context.Orders.Remove(orderToRemove);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index)); // back to Index 
        }
    }
}
