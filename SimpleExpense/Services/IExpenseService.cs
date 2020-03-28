using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleExpense.Models;

namespace SimpleExpense.Services
{
    public interface IExpenseService
    {
         Task<List<Expense>> ListAllExpenseAsync();
         Task<bool> AddExpenseAsync(Expense expense);
    }
}