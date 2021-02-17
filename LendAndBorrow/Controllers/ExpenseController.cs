using LendAndBorrow.Data;
using LendAndBorrow.Models;
using Microsoft.AspNetCore.Mvc;
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
            return View(objectList);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense obj)
        {
            _dbContext.Expenses.Add(obj);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
