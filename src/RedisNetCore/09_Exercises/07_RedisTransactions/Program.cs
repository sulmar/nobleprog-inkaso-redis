using _07_RedisTransactions.Domain;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello Transactions!");

app.MapGet("/people/{id:int}", (int id) => Results.Ok())
    .WithName("GetPersonById");

app.MapPost("/people", (Person person) =>
{
    // TODO: zapisz do REDIS jako HashSet oraz SortedSet w ramach jednej transakcji

    Results.CreatedAtRoute("GetPersonById", new { Id = person.Id }, person);
});

app.Run();
