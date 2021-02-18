using LendAndBorrow.Data;
using LendAndBorrow.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LendAndBorrow.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CategoryController(AppDbContext appDataContext)
        {
            _dbContext = appDataContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objectList = _dbContext.Categories;
            return View(objectList);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(obj);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(obj);
        }

        // Get-Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _dbContext.Categories.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _dbContext.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _dbContext.Categories.Remove(obj);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }


        // Get-Update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _dbContext.Categories.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(Category obj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(obj);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}
