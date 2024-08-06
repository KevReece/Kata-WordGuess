using System.Text;
using WordGuess.Models;

namespace WordGuess.Views;

public class GuessingWordView : IView
{
    private readonly GameModel gameModel;

    public GuessingWordView(GameModel gameModel)
    {
        this.gameModel = gameModel;
    }

    public bool ClearRender => true;

    public string Render()
    {
        var sb = new StringBuilder();
        sb.AppendLine("WORD GUESS");
        sb.AppendLine("==========\n");
        sb.AppendLine($"Words complete: {gameModel.WordsComplete}");
        sb.AppendLine($"Word: {gameModel.GetMaskedWord()}");
        sb.AppendLine($"Points: {gameModel.Points}");
        return sb.ToString();
    }
}