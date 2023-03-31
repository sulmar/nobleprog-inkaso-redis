using Microsoft.AspNetCore.HttpOverrides;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});
var app = builder.Build();

app.UseForwardedHeaders();

var redis = ConnectionMultiplexer.Connect("localhost");
var db = redis.GetDatabase();


// Note: you can simulate a different IP address by adding the X-Forwarded-For header 
app.MapGet("/", async context =>
{
    var visitorIp = context.Connection.RemoteIpAddress.ToString();
    db.HyperLogLogAdd("visitors_unique", visitorIp);
    var count = db.HyperLogLogLength("visitors_unique");
    await context.Response.WriteAsync($"Unique visitors: {count}");
});


app.Run();
