namespace WordGuess.Model;

public class WordGenerator
{
    public string Generate()
    {
        var random = new Random();
        var randomIndex = random.Next(Words.Length);
        return Words[randomIndex];
    }

    private static readonly string[] Words = new[]
    {
        "ABRACADABRA",
        "ALAKAZAM",
        "BAMBOOZLE",
        "FLABBERGAST",
        "HOODWINK",
        "MUMBOJUMBO",
        "RAZZLEDAZZLE",
        "SKEDADDLE",
        "WALLAHOOP",
        "WINGDING"
    };
}
