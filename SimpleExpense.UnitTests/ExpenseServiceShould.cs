using xunit;

namespace SimpleExpense.UnitTests
{
    public class ExpenseServiceShould
    {
        [Fact]
        public async Task AddNewExpense()
        {
            //Given
            var options = new DbContextoptionsBuilder<ExpenseDbContext>()
                .UseInMemoryDatabase(databaseaName: "Test_AddNewExpense").options;

            //When
            using(var inMemoryContext = new ExpenseDbContext(options))
            {
                var service = new ExpenseService(inMemoryContext);
                await service.AddExpenseAsync(new Expense());
            }
        
            //Then
            using (var inMemoryContext = new ExpenseDbContext(options))
            {
                Assert.Equal(1, await inMemoryContext.Expenses.CountAsync());

                var expense = await inMemoryContext.Expenses.FirstOrDefaultAsync();
                Assert.Equal(1, )
            }
        }
    }
}