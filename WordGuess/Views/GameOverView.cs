using System.Text;
using WordGuess.Models;
using WordGuess.Views;

namespace WordGuess;

public class GameOverView : IView
{
    private readonly Game game;

    public GameOverView(Game game)
    {
        this.game = game;
    }

    public bool ClearRender => true;

    public string Render()
    {
        var sb = new StringBuilder();
        sb.AppendLine("GAME OVER");
        sb.AppendLine("=========\n");
        sb.AppendLine($"Words complete: {game.WordsComplete}");
        sb.AppendLine($"Player: {game.PlayerInitials}");
        return sb.ToString();
    }
}
