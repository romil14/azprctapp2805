using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ExpenseDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
