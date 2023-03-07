using _03_RedisSets;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost:6379"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// TODO:
// Dodaæ wyszukiwanie na podstawie koloru i rozmiaru

// GET /products?color=Red
// GET /products?color=Red&Size=Large
// GET /products?Size=Large


app.MapGet("/products/{size}", (string size, IConnectionMultiplexer muxer) =>
{
    var db = muxer.GetDatabase();
    var items = db.SetMembers($"size:{size}");

    var result = items.ToStringArray();

    return Results.Ok(result);
});


await app.SeedData();


app.Run();
