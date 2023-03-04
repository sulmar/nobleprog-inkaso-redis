using _04_RedisSortedSets.Domain;
using _04_RedisSortedSets.Infrastructure;
using StackExchange.Redis;
using System.Diagnostics;

Console.WriteLine("Hello Redis Sorted Sets!");

// Zbiór posortowany leksykalnie

string filename = "Assets/female-names.txt";

Console.WriteLine("Connecting...");
var muxer = await ConnectionMultiplexer.ConnectAsync("localhost:6379");
Console.WriteLine("Connected.");

IProgress<string> progress = new Progress<string>(word => Console.Write($",{word}"));

ICompletionService completionService = new RedisCompletionService(muxer, progress);

if (!completionService.HasWords)
{
    Console.WriteLine("Seed words...");

    var stopwatch = Stopwatch.StartNew();   

    IEnumerable<string> words = File.ReadAllLines(filename);    
    completionService.AddRange(words);

    Console.WriteLine();
    Console.WriteLine($"{words.Count()} words was added in {stopwatch.Elapsed.TotalSeconds} s.");
}


string prefix;

do
{
    Console.Write("Type prefix: ");

    prefix = Console.ReadLine();

    var stopwatch = Stopwatch.StartNew();

    var autocompleteWords = completionService.Get(prefix).ToList();    
    
    foreach (var word in autocompleteWords)
    {        
        Console.WriteLine($"[{autocompleteWords.IndexOf(word)}] {word}");
    }

    Console.WriteLine($"find took: {stopwatch.Elapsed.Milliseconds} ms.");
}
while (prefix != string.Empty);

        