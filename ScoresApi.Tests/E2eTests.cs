using System.Net;
using ScoresApi.Client;

namespace ScoresApi.Tests;

public class E2eTests
{
    [Fact]
    public async Task GetTopScoresEndpointReturnsSuccess()
    {
        var client = new ScoresApiClient();
        var response = await client.GetTopScoresAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task PostScoreEndpointReturnsSuccess()
    {
        var client = new ScoresApiClient();
        var response = await client.PostScoreAsync("Test", 10);
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task GetTopScoresEndpointReturnsScore()
    {
        var client = new ScoresApiClient();
        await client.PostScoreAsync("Test", 10);
        var response = await client.GetTopScoresAsync();

        var responseText = await response.Content.ReadAsStringAsync();
        Assert.Contains("value", responseText);
    }
}
