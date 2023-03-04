using _01_RedisStrings.Domain;
using Microsoft.EntityFrameworkCore;

namespace _01_RedisStrings.Infrastructure;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions options) : base(options) {}
    public DbSet<Customer> Customers { get; set; }
}
