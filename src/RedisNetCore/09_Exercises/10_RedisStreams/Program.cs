using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    // TODO: 

    await next();
});


app.MapGet("/", () => "Hello Streams!");

app.MapGet("/cart", async () =>
{
    // ...

    return Results.Ok();

});

app.MapGet("/cart/{productId:int}", async (int productId) =>
{
    // ...

    return Results.Ok();
});

app.MapPost("/cart/{productId:int}", async ([FromQuery] int? quantity) =>
{
    // ...

    return Results.NoContent();
});

app.MapPut("/cart/{productId:int}", async (int productId) =>
{
    // ...

    return Results.NoContent();

});

app.MapDelete("/cart/{productId:int}", async (int productId) =>
{
    // ...

    return Results.Ok();
});

app.Run();
