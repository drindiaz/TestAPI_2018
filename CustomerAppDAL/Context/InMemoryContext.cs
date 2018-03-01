using CustomerAppDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerAppDAL.Context
{
    class InMemoryContext : DbContext
    {
        static DbContextOptions<InMemoryContext> options =
            new DbContextOptionsBuilder<InMemoryContext>()
                .UseInMemoryDatabase("TheDB")
                .Options;
        public InMemoryContext() : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
