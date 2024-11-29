using Eshop.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Eshop.WebApi.Tests
{
    public abstract class TestBase
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        protected EshopDbContext dbContext;
        protected DbContextOptions<EshopDbContext> dbContextOptions;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [SetUp]
        public async Task SetUp()
        {
            dbContextOptions = new DbContextOptionsBuilder<EshopDbContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;

            dbContext = new EshopDbContext(dbContextOptions);

            await dbContext.Database.OpenConnectionAsync();
            await dbContext.Database.EnsureCreatedAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.Database.CloseConnectionAsync();
            await dbContext.DisposeAsync();
        }
    }
}