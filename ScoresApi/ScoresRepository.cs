namespace ScoresApi;

public class ScoresRepository
{
    public IEnumerable<Score> GetTopScores()
    {
        return Enumerable.Range(1, 3).Select(index =>
            new Score
                (
                    DateTime.Now.AddDays(-2),
                    "ABC",
                    10
                ));
    }

    public void AddScore(Score score)
    {
    }
}