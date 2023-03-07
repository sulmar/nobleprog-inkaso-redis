using _01_RedisStrings;
using _01_RedisStrings.Domain;
using _01_RedisStrings.Infrastructure;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Net.Mime;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.Configuration["JsonPlaceholder:Url"]) });

builder.Services.AddScoped<ICustomerRepository, DbCustomerRepository>();
builder.Services.Decorate<ICustomerRepository, CachedCustomerRepository>();
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost:6379"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// TODO: Add cache
app.MapGet("/users", async (HttpClient client) =>
{
    var users = await client.GetStringAsync("/users");

    return Results.Text(users, MediaTypeNames.Application.Json);

});

// TODO: Add cache
app.MapGet("/users/{id:int}", async (int id, HttpClient client) =>
{
    var user = await client.GetStringAsync($"/users/{id}");

    return Results.Text(user, MediaTypeNames.Application.Json);

});

// TODO: Add cache
app.MapGet("/customers/{id:int}", (int id, ICustomerRepository repository) => repository.GetAsync(id));

await app.SeedData();

app.Run();

