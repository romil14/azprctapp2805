using Microsoft.EntityFrameworkCore;
using CoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Data
{
    public class ExpenseDbContext : DbContext
    {
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options): base(options)
        {
        }

        public DbSet<ExpenseDetails> ExpenseDetails { get; set; }

        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
    }
}
