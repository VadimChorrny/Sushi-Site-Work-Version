using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SushiSite.Data;
using SushiSite.Models;
using SushiSite.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SushiSite.Controllers
{
    //[Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string searchString)
        {
            var orders = from e in _context.Orders
                        select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(s => s.Surname!.Contains(searchString));
            }
            return View(orders);
        }
        public IActionResult AddNewFood()
        {
            FoodViewModel viewModel = new FoodViewModel()
            {
                Category = _context.Categories.Select(e => new SelectListItem() { Text = e.Name, Value = e.Id.ToString() })
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddNewFood(FoodViewModel model)
        {
            if(!ModelState.IsValid) return View();
            _context.Foods.Add(model.Food);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult DeleteFood(int? id)
        {
            if (id == null || id <= 0) return NotFound();
            var foodToRemove = _context.Foods.Find(id);
            if (foodToRemove == null) return NotFound();
            _context.Foods.Remove(foodToRemove);
            _context.SaveChanges();
            return RedirectToAction(nameof(ShowAllFoods));
        }
        public IActionResult EditFood(int? id)
        {
            if (id == null || id <= 0) return NotFound();

            var food = _context.Foods.Find(id);

            if (food == null) return NotFound();

            IEnumerable<SelectListItem> categories = _context.Categories.Select(e => new SelectListItem()
            { Text = e.Name, Value = e.Id.ToString() });
            ViewBag.CategoryList = categories;

            return View(food);
        }
        [HttpPost]
        public IActionResult EditFood(Food obj)
        {
            if (!ModelState.IsValid) return View();

            _context.Foods.Update(obj);
            _context.SaveChanges();
            return RedirectToAction(nameof(ShowAllFoods));
        }

        public IActionResult ShowAllFoods() => View(_context.Foods.ToList());
        public IActionResult ShowAllOrders() => View(_context.Orders.ToList());

    }
}
