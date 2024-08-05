using System.Net;
using System.Text;
using System.Text.Json;

namespace ScoresApi.Tests;

public class E2eTests
{
    [Fact]
    public async Task GetTopScoresEndpointReturnsSuccess()
    {
        var client = new ScoresApiClient();
        var response = await client.Get("/topscores");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task GetTopScoresEndpointReturnsScore()
    {
        var client = new ScoresApiClient();
        var response = await client.Get("/topscores");

        var responseText = await response.Content.ReadAsStringAsync();
        Assert.Contains("value", responseText);
    }
    
    [Fact]
    public async Task PostScoreEndpointReturnsSuccess()
    {
        var client = new ScoresApiClient();
        var response = await client.Post("/score", "Test", 10);
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    public class ScoresApiClient : HttpClient
    {
        private static readonly HttpClientHandler handler = new() {};

        public ScoresApiClient() : base(handler)
        {
            BaseAddress = new Uri("http://localhost:5195");
        }

        public Task<HttpResponseMessage> Get(string path)
        {
            return GetAsync(path);
        }

        public Task<HttpResponseMessage> Post(string path, string name, int value)
        {
            var score = new Score(DateTime.Now, name, value);
            var content = new StringContent(JsonSerializer.Serialize(score), Encoding.UTF8, "application/json");
            return PostAsync(path, content);
        }
    }

    public record Score(DateTime Date, string Name, int Value)
    {
    }
}
