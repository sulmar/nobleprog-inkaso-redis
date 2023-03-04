using _04_RedisSortedSets.Domain;
using StackExchange.Redis;

namespace _04_RedisSortedSets.Infrastructure;

public class RedisCompletionService : ICompletionService
{
    private readonly IConnectionMultiplexer muxer;
    private IDatabase db => muxer.GetDatabase();
    private const string key = "words";

    private readonly IProgress<string> progress;

    private const int rangelen = 50; // This is not random, try to get replies < MTU size

    public RedisCompletionService(IConnectionMultiplexer muxer, IProgress<string> progress)
    {
        this.muxer = muxer;
        this.progress = progress;
    }

    public bool HasWords => db.KeyExists(key);

    public void AddRange(IEnumerable<string> words)
    {
        foreach (string word in words)
        {
            Add(word);            
        }
    }

    private void Add(string word)
    {
        for (int l = 1; l < word.Length; l++)
        {
            string prefix = word[..l];
            // ZADD key prefix
            db.SortedSetAdd(key, member: prefix, score: 0);
        }

        // ZADD key foo*
        db.SortedSetAdd(key, member: $"{word}*", score: 0);

        progress?.Report(word);
    }

    public IEnumerable<string> Get(string prefix)
    {
        // ZRANK key fo
        long? start = db.SortedSetRank(key, prefix);

        if (start.HasValue)
        {
            // ZRANGE key 6 -1
            var range = db.SortedSetRangeByRank(key, start.Value, start.Value + rangelen - 1);

            var results = range
                .Select(entry => entry.ToString())
                .Where(entry => entry.StartsWith(prefix))
                .Where(entry => entry.EndsWith("*"))
                .Select(entry => entry[..^1]);

            return results;
        }
        else
            return Enumerable.Empty<string>();
    }   
}


