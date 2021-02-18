using LendAndBorrow.Data;
using LendAndBorrow.Models;
using LendAndBorrow.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LendAndBorrow.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ExpenseController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> objectList = _dbContext.Expenses;

            foreach (var obj in objectList)
            {
                obj.ExpenseCategory = _dbContext.Categories.FirstOrDefault(u => u.Id == obj.ExpenseCategoryId);
            }

            return View(objectList);
        }

        public IActionResult Create()
        {
            //IEnumerable<SelectListItem> TypeDropDown = _dbContext.Categories.Select(i => new SelectListItem
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString()
            //});

            // Way to pass the data from controller to the View
            //ViewBag.TypeDropDown = TypeDropDown;

            ExpenseVm expenseVm = new ExpenseVm()
            {
                Expense = new Expense(),
                TypeDropDown = _dbContext.Categories.Select(i => new SelectListItem {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            return View(expenseVm);
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseVm obj)
        {
            if (ModelState.IsValid)
            {

                _dbContext.Expenses.Add(obj.Expense);
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

            var obj = _dbContext.Expenses.Find(id);

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
            var obj = _dbContext.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _dbContext.Expenses.Remove(obj);
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

            var obj = _dbContext.Expenses.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Expenses.Update(obj);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}
