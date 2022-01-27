using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SushiSite.Data;
using SushiSite.Models;
using System.Collections.Generic;
using System.Linq;

namespace SushiSite.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Categories.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid) return View();
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var categoryToRemove = _context.Categories.Find(id);
            if (categoryToRemove == null) return NotFound();
            _context.Categories.Remove(categoryToRemove);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0) return NotFound();

            var ganre = _context.Categories.Find(id);

            if (ganre == null) return NotFound();

            IEnumerable<SelectListItem> categories = _context.Categories.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            ViewBag.CategoryList = categories;

            return View(ganre);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (!ModelState.IsValid) return View();

            _context.Categories.Update(obj);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
