using StackExchange.Redis;

namespace _03_RedisSets;

public static class WebApplicationExtensions
{
    public static async Task SeedData(this WebApplication app)
    {
        var mutex = app.Services.CreateScope().ServiceProvider.GetRequiredService<IConnectionMultiplexer>();

        var db = mutex.GetDatabase();        

        await db.SetAddAsync("size:Small", "product:1");
        await db.SetAddAsync("size:Small", "product:2");
        await db.SetAddAsync("size:Small", "product:3");

        await db.SetAddAsync("size:Medium", "product:1");
        await db.SetAddAsync("size:Medium", "product:3");
        await db.SetAddAsync("size:Medium", "product:4");

        await db.SetAddAsync("size:Large", "product:1");
        await db.SetAddAsync("size:Large", "product:2");
        await db.SetAddAsync("size:Large", "product:5");

        await db.SetAddAsync("color:Red", "product:1");
        await db.SetAddAsync("color:Red", "product:3");
        await db.SetAddAsync("color:Red", "product:4");

        await db.SetAddAsync("color:Green", "product:2");
        await db.SetAddAsync("color:Green", "product:5");
    }
}

