using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleExpense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExpense.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class ExpenseController : ControllerBase
    {
        private readonly ExpenseDbContext _expenseDbContext;
        public ExpenseController(ExpenseDbContext expenseDbContext)
        {
            _expenseDbContext = expenseDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Expense>>> GetAllExpense()
        {
            var expenses = await _expenseDbContext.Expenses.ToListAsync();
            return expenses;
        }

        [HttpPost]
        public async Task<ActionResult> AddExpense([FromBody] Expense expense)
        {
                if(expense == null || !ModelState.IsValid)
                {
                    throw new Exception("Model cannot be Empty");
                }
                _expenseDbContext.Expenses.Add(expense);
                await _expenseDbContext.SaveChangesAsync();

                return Ok(new {
                    date = expense.Date,
                    value = expense.Value,
                    reason = expense.Reason
                });
        }
    }
}
