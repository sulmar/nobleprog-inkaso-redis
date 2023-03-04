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



await app.SeedData();


app.Run();
