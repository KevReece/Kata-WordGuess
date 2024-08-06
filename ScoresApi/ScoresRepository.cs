using System.Text.Json;
using StackExchange.Redis;

namespace ScoresApi;

public class ScoresRepository
{
    private readonly IDatabase _database;
    
    public ScoresRepository()
    {
        var redisConnectionString = Environment.GetEnvironmentVariable("REDIS_CONNECTION_STRING") ?? "redis:6379";
        var redis = ConnectionMultiplexer.Connect(redisConnectionString);
        _database = redis.GetDatabase();
    }

    public IEnumerable<Score> GetTopScores()
    {
        var scores = _database.SortedSetRangeByRankWithScores("scores", 0, 9, Order.Descending);
        return scores.Select(DeserialiseEntry);
    }

    private static Score DeserialiseEntry(SortedSetEntry entry)
    {
        if (entry.Element.IsNull)
        {
            throw new InvalidOperationException("Null entry in scores");
        }
        return JsonSerializer.Deserialize<Score>(entry.Element!) 
            ?? throw new InvalidOperationException("Failed to deserialise score");
    }

    public void AddScore(Score score)
    {
        var scoreJson = JsonSerializer.Serialize(score);
        _database.SortedSetAdd("scores", scoreJson, score.Value);
    }
}
