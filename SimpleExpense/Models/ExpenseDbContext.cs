using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExpense.Models
{
    public class ExpenseDbContext : DbContext 
    {
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : base(options)
        {
            
        }

        public DbSet<Expense> Expenses { get; set; }
    }
 }
