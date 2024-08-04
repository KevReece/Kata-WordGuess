using System.Net;

namespace ScoresApi.Tests;

public class E2eTests
{
    [Fact]
    public void ScoresEndpointReturnsSuccess()
    {
        var client = new ScoresApiClient();
        var response = client.Get("/scores");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task ScoresEndpointReturnsScore()
    {
        var client = new ScoresApiClient();
        var response = client.Get("/scores");

        var responseText = await response.Content.ReadAsStringAsync();
        Assert.Contains("value", responseText);
    }

    public class ScoresApiClient : HttpClient
    {
        private static readonly HttpClientHandler handler = new() {};

        public ScoresApiClient() : base(handler)
        {
            BaseAddress = new Uri("http://localhost:5195");
        }

        public HttpResponseMessage Get(string path)
        {
            return GetAsync(path).Result;
        }
    }
}
