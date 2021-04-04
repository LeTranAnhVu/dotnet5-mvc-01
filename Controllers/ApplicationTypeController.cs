using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MvcTest.Data;
using MvcTest.Models;

namespace MvcTest.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private ApplicationDbContext _context;
        public ApplicationTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> applicationTypes = _context.ApplicationTypes.ToList();
            return View(applicationTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType applicationType)
        {
            _context.ApplicationTypes.Add(applicationType);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}