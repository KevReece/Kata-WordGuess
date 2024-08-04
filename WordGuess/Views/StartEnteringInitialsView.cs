using System.Text;
using WordGuess.Models;

namespace WordGuess.Views;

public class StartEnteringInitialsView : IView
{
    private readonly Game game;

    public StartEnteringInitialsView(Game game)
    {
        this.game = game;
    }

    public bool ClearRender { get; private set; } = true;

    public string Render()
    {
        var sb = new StringBuilder();
        sb.AppendLine("GAME OVER");
        sb.AppendLine("=========\n");
        sb.AppendLine($"Words complete: {game.WordsComplete}");
        sb.AppendLine($"Word: {game.GetMaskedWord()}");
        sb.AppendLine($"Points: {game.Points}");
        sb.AppendLine("Enter your initials:");
        return sb.ToString();
    }
}