using WordGuess.Model;
using WordGuess.Models;
using WordGuess.Views;

namespace WordGuess.States;

public class GuessingWordState : IState
{
    private readonly GameModel gameModel;
    private readonly WordGenerator wordGenerator;
    private readonly IStateFactory stateFactory;

    public GuessingWordState(GameModel gameModel, WordGenerator wordGenerator, IStateFactory stateFactory)
    {
        this.gameModel = gameModel;
        this.wordGenerator = wordGenerator;
        this.stateFactory = stateFactory;
    }

    public IView View => new GuessingWordView(gameModel);
    public Interaction Interaction => Interaction.GetKey;

    public IState Act(char? pressedKey)
    {
        if (gameModel.Word is null)
        {
            throw new InvalidOperationException("Word is not set.");
        }
        if (pressedKey.HasValue && char.IsLetter(pressedKey.Value))
        {
            var pressedChar = char.ToUpperInvariant(pressedKey.Value);
            var ordinalDifference = Math.Abs(gameModel.Word[gameModel.CurrentCharIndex] - pressedChar);
            gameModel.Points -= ordinalDifference;
            gameModel.CurrentCharIndex++;
        }
        if (gameModel.Points <= 0)
        {
            return stateFactory.CreateEnteringInitialsState();
        }
        if (gameModel.CurrentCharIndex == gameModel.Word.Length)
        {
            gameModel.WordsComplete++;
            gameModel.Word = wordGenerator.Generate();
            gameModel.CurrentCharIndex = 1;
            gameModel.Points += 10;
            return stateFactory.CreateGuessingWordState();
        }
        return this;
    }
}
