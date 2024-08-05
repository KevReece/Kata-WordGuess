namespace ScoresApi;

public static class Routes
{
    public static void RegisterRoutes(this WebApplication app, ScoresRepository scoresRepository)
    {
        app.MapGet("/topscores", scoresRepository.GetTopScores)
            .WithName("GetTopScores");

        app.MapPost("/score", (Score score) => scoresRepository.AddScore(score))
            .WithName("PostScore");
    }
}