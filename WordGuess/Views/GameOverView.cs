using System.Text;
using WordGuess.Models;

namespace WordGuess.Views;

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
        sb.AppendLine($"Player: {game.PlayerInitials}\n");
        sb.AppendLine("Top Scores:");
        sb.AppendLine("-----------\n");
        foreach (var (player, score) in game.TopScores!)
        {
            sb.AppendLine($"Player:{player}, Words complete:{score}");
        }
        return sb.ToString();
    }
}
