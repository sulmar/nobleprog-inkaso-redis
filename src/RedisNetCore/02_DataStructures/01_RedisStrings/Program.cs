using StackExchange.Redis;

Console.WriteLine("Hello Redis Strings!");


// dotnet add package StackExchange.Redis


var muxer = ConnectionMultiplexer.Connect(new ConfigurationOptions()
{
    EndPoints = { "localhost:6379" }
});


var db = muxer.GetDatabase();

var trainerNameKey = new RedisKey("trainer:name");

// SET
db.StringSet(trainerNameKey, "Marcin");

// GET
var trainerName = db.StringGet(trainerNameKey);

Console.WriteLine(trainerName);

// INCR
db.StringIncrement("points", 1);
db.StringIncrement("points", 1);

// INCRBY
db.StringIncrement("points", 5);

var points = db.StringGet("points");

if (points.HasValue && points.IsInteger)
{    
    Console.WriteLine($"points: {int.Parse(points)}");
}

var message = db.StringGet("message");
if (!message.IsNull)
    Console.WriteLine(message);






