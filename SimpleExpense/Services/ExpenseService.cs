using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleExpense.Models;

namespace SimpleExpense.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly ExpenseDbContext _expenseDbContext;
        public ExpenseService(ExpenseDbContext expenseDbContext) => _expenseDbContext = expenseDbContext;
        
        public async Task<List<Expense>> ListAllExpenseAsync()
        {
            return await _expenseDbContext.Expenses.ToListAsync();
        }

        public async Task<bool> AddExpenseAsync(Expense expense)
        {
            _expenseDbContext.Expenses.Add(expense);
            var saveResult =  await _expenseDbContext.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}