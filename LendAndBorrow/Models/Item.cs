using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LendAndBorrow.Models
{
    public class Item
    {
        public int Id { get; set; }

        [DisplayName("Item name")]
        public string ItemName { get; set; }
        public string Borrower { get; set; }
        public string Lender { get; set; }

    }
}
