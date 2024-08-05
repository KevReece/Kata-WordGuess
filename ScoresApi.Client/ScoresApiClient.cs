namespace ScoresApi.Client;

using System.Text;
using System.Text.Json;

public class ScoresApiClient : HttpClient, IScoresApiClient
{
    private static readonly HttpClientHandler handler = new() {};

    public ScoresApiClient() : base(handler)
    {
        BaseAddress = new Uri("http://localhost:5195");
    }

    public async Task<HttpResponseMessage> GetTopScoresAsync()
    {
        return await GetAsync("/topscores");
    }

    public async Task<HttpResponseMessage> PostScoreAsync(string name, int value)
    {
        var score = new Score(DateTime.Now, name, value);
        var content = new StringContent(JsonSerializer.Serialize(score), Encoding.UTF8, "application/json");
        return await PostAsync("/score", content);
    }
}
