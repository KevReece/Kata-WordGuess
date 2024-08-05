using WordGuess.Model;
using WordGuess.Models;
using WordGuess.Views;

namespace WordGuess.States;

public class GuessingWordState : IState
{
    private readonly Game game;
    private readonly WordGenerator wordGenerator;
    private readonly IStateFactory stateFactory;

    public GuessingWordState(Game game, WordGenerator wordGenerator, IStateFactory stateFactory)
    {
        this.game = game;
        this.wordGenerator = wordGenerator;
        this.stateFactory = stateFactory;
    }

    public IView View => new GuessingWordView(game);
    public Interaction Interaction => Interaction.GetKey;

    public IState Act(char? pressedKey)
    {
        if (game.Word is null)
        {
            throw new InvalidOperationException("Word is not set.");
        }
        if (pressedKey.HasValue && char.IsLetter(pressedKey.Value))
        {
            var pressedChar = char.ToUpperInvariant(pressedKey.Value);
            var ordinalDifference = Math.Abs(game.Word[game.CurrentCharIndex] - pressedChar);
            game.Points -= ordinalDifference;
            game.CurrentCharIndex++;
        }
        if (game.Points <= 0)
        {
            return stateFactory.CreateEnteringInitialsState();
        }
        if (game.CurrentCharIndex == game.Word.Length)
        {
            game.WordsComplete++;
            game.Word = wordGenerator.Generate();
            game.CurrentCharIndex = 1;
            game.Points += 10;
            return stateFactory.CreateGuessingWordState();
        }
        return this;
    }
}
