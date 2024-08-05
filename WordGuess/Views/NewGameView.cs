using System.Text;
using WordGuess.Models;
using WordGuess.Views;

namespace WordGuess;

public class NewGameView : IView
{
    public bool ClearRender => false;

    public string Render()
    {
        var sb = new StringBuilder();
        sb.AppendLine("WORD GUESS");
        sb.AppendLine("=========\n");
        sb.AppendLine("Welcome to Word Guess! Simply enter each letter to guess the word.");
        sb.AppendLine("Incorrect letter guesses will lose you points by alphabetical distance.");
        sb.AppendLine("Completing a word gains you 10 points.");
        sb.AppendLine("Go below 0 points and it's game over.");
        sb.AppendLine("Press any key to begin. Let's go!");
        return sb.ToString();
    }
}
