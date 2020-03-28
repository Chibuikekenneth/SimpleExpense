using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleExpense.Models;
using SimpleExpense.Services;
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
        private readonly IExpenseService _expenseService;
        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Expense>>> GetAllExpense()
        {
            return await _expenseService.ListAllExpenseAsync();
        }

        [HttpPost]
        public async Task<ActionResult> AddExpense([FromBody] Expense expense)
        {
                if(expense == null || !ModelState.IsValid)
                {
                    throw new Exception("Model cannot be Empty");
                }       
                await _expenseService.AddExpenseAsync(expense);
                return Ok(new {
                    date = expense.Date,
                    value = expense.Value,
                    reason = expense.Reason
                });
        }
    }
}
