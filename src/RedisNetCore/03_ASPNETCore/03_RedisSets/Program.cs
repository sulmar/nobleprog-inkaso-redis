using _03_RedisSets;
using StackExchange.Redis;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost:6379"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");



app.MapGet("/products/size/{size}", (string size, IConnectionMultiplexer muxer) =>
{
    var key = $"{nameof(size)}:{size}";

    var db = muxer.GetDatabase();
    var items = db.SetMembers(key);

    var result = items.ToStringArray();

    return Results.Ok(result);
});

app.MapGet("/products/color/{color}", (string color, IConnectionMultiplexer muxer) =>
{
    var key = $"{nameof(color)}:{color}";

    var db = muxer.GetDatabase();
    var items = db.SetMembers(key);

    var result = items.ToStringArray();

    return Results.Ok(result);
});


app.MapGet("/products/size/all", async (IConnectionMultiplexer muxer) =>
{
    var key = "size:all";
    
    var db = muxer.GetDatabase();

   var items = await db.SetMembersAsync(key);
   
    var result = items.ToStringArray();

    return Results.Ok(result);
});

app.MapMethods("/products/size/{size}/{id:int}", new[] { "HEAD" }, async (string size, int id, IConnectionMultiplexer muxer) =>
{
    var db = muxer.GetDatabase();

    var contains =  await db.SetContainsAsync($"size:{size}", $"product:{id}");

    return contains ? Results.Ok() : Results.NotFound();
});

app.MapGet("/products", async ([AsParameters]ProductSearchParameters parameters, IConnectionMultiplexer muxer) =>
{
    var db = muxer.GetDatabase();

    var keys = Enumerable.Empty<RedisKey>().ToList();

    if (parameters.Color is not null)
    {
        keys.Add($"color:{parameters.Color}");
    }

    if (parameters.Size is not null)
    {
        keys.Add($"size:{parameters.Size}");
    }

    var items = await db.SetCombineAsync(SetOperation.Intersect, keys.ToArray());

    var result = items.ToStringArray();

    return Results.Ok(result);


});

await app.SeedData();


app.Run();

record ProductSearchParameters(string? Color, string? Size);

