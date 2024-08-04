using System.Text;
using WordGuess.Models;

namespace WordGuess;

public class GuessingWordView : IView
{
    private readonly Game game;

    public GuessingWordView(Game game)
    {
        this.game = game;
    }

    public bool ClearRender => true;

    public string Render()
    {
        var sb = new StringBuilder();
        sb.AppendLine("WORD GUESS");
        sb.AppendLine("==========\n");
        sb.AppendLine($"Words complete: {game.WordsComplete}");
        sb.AppendLine($"Word: {game.GetMaskedWord()}");
        sb.AppendLine($"Points: {game.Points}");
        return sb.ToString();
    }
}