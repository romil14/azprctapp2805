using System;

namespace CoreModels
{
    public class ExpenseDetails
    {
        public int ExpenseDetailsId { get; set; }

        public DateTime ExpenseDate { get; set; }

        public double Amount { get; set; }

        public string Notes { get; set; }

        public int ExpenseCategoryId { get; set; }
    }
}
