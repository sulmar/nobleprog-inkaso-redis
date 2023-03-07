using StackExchange.Redis;

Console.WriteLine("Hello Redis Pipelining!");


// dotnet add package StackExchange.Redis


var muxer = ConnectionMultiplexer.Connect(new ConfigurationOptions()
{
    EndPoints = { "localhost:6379" }
});


var db = muxer.GetDatabase();

// PING

var batch = db.CreateBatch();

// gwarantuje kolejnosc wykonywania polecen

for (int i = 0; i < 1000; i++)
{
    var response = await batch.PingAsync();
    Console.WriteLine($"The ping took {response.TotalMilliseconds} ms");
}

batch.Execute();


