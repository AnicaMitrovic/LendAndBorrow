﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LendAndBorrow.Models.ViewModel
{
    public class ExpenseVm
    {
        public Expense Expense { get; set; }

        public IEnumerable<SelectListItem> TypeDropDown { get; set; }
    }
}
