using StackExchange.Redis;

Console.WriteLine("Hello Redis HyperLogLog !");


// dotnet add package StackExchange.Redis

var muxer = ConnectionMultiplexer.Connect(new ConfigurationOptions()
{
    EndPoints = { "localhost:6379" }
});

var db = muxer.GetDatabase();

var visitorIp = "192.168.0.1"; // replace with the actual visitor IP address
db.HyperLogLogAdd("visitors_unique", visitorIp);

db.HyperLogLogAdd("visitors_unique", "192.168.0.1");
db.HyperLogLogAdd("visitors_unique", "192.168.0.1");
db.HyperLogLogAdd("visitors_unique", "192.168.0.1");
db.HyperLogLogAdd("visitors_unique", "192.168.0.100");
db.HyperLogLogAdd("visitors_unique", "192.168.0.100");

var count = db.HyperLogLogLength("visitors_unique");

Console.WriteLine($"Unique visitors: {count}");