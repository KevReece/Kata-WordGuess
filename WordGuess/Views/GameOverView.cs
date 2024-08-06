using System.Text;
using WordGuess.Models;

namespace WordGuess.Views;

public class GameOverView : IView
{
    private readonly GameModel gameModel;

    public GameOverView(GameModel gameModel)
    {
        this.gameModel = gameModel;
    }

    public bool ClearRender => true;

    public string Render()
    {
        var sb = new StringBuilder();
        sb.AppendLine("GAME OVER");
        sb.AppendLine("=========\n");
        sb.AppendLine($"Words complete: {gameModel.WordsComplete}");
        sb.AppendLine($"Player: {gameModel.PlayerInitials}\n");
        sb.AppendLine("Top Scores:");
        sb.AppendLine("-----------\n");
        foreach (var (player, score) in gameModel.TopScores!)
        {
            sb.AppendLine($"Player:{player}, Words complete:{score}");
        }
        return sb.ToString();
    }
}
