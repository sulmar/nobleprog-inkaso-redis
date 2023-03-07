using StackExchange.Redis;

namespace _03_RedisSets;

public static class WebApplicationExtensions
{
    public static async Task SeedData(this WebApplication app)
    {
        var mutex = app.Services.CreateScope().ServiceProvider.GetRequiredService<IConnectionMultiplexer>();

        var db = mutex.GetDatabase();        

        await db.SetAddAsync("size:small", "product:1");
        await db.SetAddAsync("size:small", "product:2");
        await db.SetAddAsync("size:small", "product:3");

        await db.SetAddAsync("size:medium", "product:1");
        await db.SetAddAsync("size:medium", "product:3");
        await db.SetAddAsync("size:medium", "product:4");

        await db.SetAddAsync("size:large", "product:1");
        await db.SetAddAsync("size:large", "product:2");
        await db.SetAddAsync("size:large", "product:5");

        await db.SetAddAsync("color:red", "product:1");
        await db.SetAddAsync("color:red", "product:3");
        await db.SetAddAsync("color:red", "product:4");

        await db.SetAddAsync("color:green", "product:2");
        await db.SetAddAsync("color:green", "product:5");

        var sizeKeys = new RedisKey[]
        {
            "size:small",
            "size:medium",
            "size:large",
        };

        await db.SetCombineAndStoreAsync(SetOperation.Union, "size:all", sizeKeys);
        
    }
}

