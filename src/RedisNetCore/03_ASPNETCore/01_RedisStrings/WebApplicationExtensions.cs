using _01_RedisStrings.Domain;
using _01_RedisStrings.Infrastructure;
using Bogus;

namespace _01_RedisStrings;

public static class WebApplicationExtensions
{
    public static async Task SeedData(this WebApplication app)
    {        
        var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationContext>();

        context.Database.EnsureCreated();

        if (!context.Customers.Any())
        {
            var customers = new Faker<Customer>()
                .Ignore(p => p.Id)
                .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                .RuleFor(p => p.LastName, f => f.Person.LastName)
                .Generate(100);

            await context.Customers.AddRangeAsync(customers);
            await context.SaveChangesAsync();
        }
    }
}
