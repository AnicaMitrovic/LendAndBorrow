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

        public IActionResult Create()
        {
            IEnumerable<Item> objectList = _db.Items;
            return View();
        }
    }
}
