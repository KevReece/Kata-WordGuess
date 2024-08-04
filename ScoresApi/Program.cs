var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/scores", () =>
    {
        var scores = Enumerable.Range(1, 3).Select(index =>
            new Score
                (
                    DateTime.Now.AddDays(-2),
                    "ABC",
                    10
                ))
            .ToArray();
        return scores;
    })
    .WithName("GetScores");

app.Run();

record Score(DateTime Date, string Name, int Value)
{
}
