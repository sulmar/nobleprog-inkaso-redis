var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello Redis Sorted Sets!");

// Seed data
var ranks = File.ReadAllLines("ranking.txt")
    .Skip(1)
    .Select(line => line.Split('\t'))
    .Select(columns => new { Rank = int.Parse(columns[1]), Name = columns[2] });

app.Run();