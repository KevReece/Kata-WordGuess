namespace ScoresApi.Client;

public interface IScoresApiClient
{
    Task<HttpResponseMessage> GetTopScoresAsync();
    Task<HttpResponseMessage> PostScoreAsync(string name, int value);
}