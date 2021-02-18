using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LendAndBorrow.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0!")]
        public int Amount { get; set; }
       
        [Required]
        public string Name { get; set; }

        // Connection between 2 tables
        [DisplayName("Expense Category")]
        public int ExpenseCategoryId { get; set; }

        [ForeignKey("ExpenseType")]
        public virtual Category ExpenseCategory { get; set; }

    }
}
