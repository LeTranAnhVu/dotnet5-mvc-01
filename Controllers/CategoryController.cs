using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MvcTest.Data;
using MvcTest.Models;

namespace MvcTest.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category categoryForm)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryForm);
            }

            _context.Categories.Add(categoryForm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category categoryForm)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryForm);
            }

            _context.Categories.Update(categoryForm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            _context.Remove(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}