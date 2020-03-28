using Microsoft.EntityFrameworkCore;
using SimpleExpense.Models;
using SimpleExpense.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SimpleExpense.UnitTests
{
    public class ExpenseServiceShould
    {
        [Fact]
        public async Task AddNewExpense()
        {
            //Given
            var options = new DbContextOptionsBuilder<ExpenseDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_AddNewExpense").Options;

            //When
            using(var inMemoryContext = new ExpenseDbContext(options))
            {
                var service = new ExpenseService(inMemoryContext);

                var fakeExpense = new Expense
                {
                    Id = 1,
                    Reason = "Bought a new MacBook",
                    Value = 700000,
                    Date = DateTime.Today
                };

                await service.AddExpenseAsync(fakeExpense);
            }
        
            //Then
            using (var inMemoryContext = new ExpenseDbContext(options))
            {
                Assert.Equal(1, await inMemoryContext.Expenses.CountAsync());
                var expense = await inMemoryContext.Expenses.FirstOrDefaultAsync();
                Assert.Equal(1, expense.Id);
                Assert.Equal(DateTime.Today, expense.Date);
                Assert.Equal(700000, expense.Value);
                Assert.Equal("Bought a new MacBook", expense.Reason);
            }
        }
    }
}