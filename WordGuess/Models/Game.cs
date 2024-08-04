namespace WordGuess.Models;

public class Game
{
    public string? Word { get; set; }
    public int Points { get; set; } = 100;
    public int CurrentCharIndex { get; set; } = 1;
    public string PlayerInitials { get; set; } = string.Empty;
    public int WordsComplete { get; set; } = 0;
    
    public string GetMaskedWord()
    {
        if (string.IsNullOrEmpty(Word))
        {
            return string.Empty;
        }
        var maskedWord = string.Empty;
        for (var i = 0; i < Word.Length; i++)
        {
            if (i < CurrentCharIndex)
            {
                maskedWord += Word[i];
            }
            else
            {
                maskedWord += "_";
            }
        }
        return maskedWord;
    }
}