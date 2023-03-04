using _01_RedisStrings.Domain;

namespace _01_RedisStrings.Infrastructure;

public class DbCustomerRepository : ICustomerRepository
{
    private readonly ApplicationContext db;

    public DbCustomerRepository(ApplicationContext db) => this.db = db;

    public async Task<Customer?> GetAsync(int id) => await db.Customers.FindAsync(id);
    
}
