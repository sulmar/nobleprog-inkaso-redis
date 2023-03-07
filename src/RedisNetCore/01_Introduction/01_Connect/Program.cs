using StackExchange.Redis;

Console.WriteLine("Hello Redis!");

// dotnet add package StackExchange.Redis

var muxer = ConnectionMultiplexer.Connect(new ConfigurationOptions()
{
    EndPoints = { "localhost:6379" }
});


var db = muxer.GetDatabase();

// PING
var response = await db.PingAsync();

Console.WriteLine($"The ping took {response.TotalMilliseconds} ms");


