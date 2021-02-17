using LendAndBorrow.Data;
using LendAndBorrow.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LendAndBorrow.Controllers
{
    public class ItemController : Controller
    {
        private readonly AppDbContext _db;

        public ItemController(AppDbContext appDb)
        {
            _db = appDb;
        }

        public IActionResult Index()
        {
            IEnumerable<Item> objectList = _db.Items;
            return View(objectList);
        }

        // GET-Create
        public IActionResult Create()
        {
            return View();
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            _db.Items.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
