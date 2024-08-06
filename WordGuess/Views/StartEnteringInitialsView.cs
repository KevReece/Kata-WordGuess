using System.Text;
using WordGuess.Models;

namespace WordGuess.Views;

public class StartEnteringInitialsView : IView
{
    private readonly GameModel gameModel;

    public StartEnteringInitialsView(GameModel gameModel)
    {
        this.gameModel = gameModel;
    }

    public bool ClearRender { get; private set; } = true;

    public string Render()
    {
        var sb = new StringBuilder();
        sb.AppendLine("GAME OVER");
        sb.AppendLine("=========\n");
        sb.AppendLine($"Words complete: {gameModel.WordsComplete}");
        sb.AppendLine($"Word: {gameModel.GetMaskedWord()}");
        sb.AppendLine($"Points: {gameModel.Points}");
        sb.AppendLine("Enter your initials:");
        return sb.ToString();
    }
}