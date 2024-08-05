using WordGuess.Model;
using WordGuess.Models;
using WordGuess.Views;

namespace WordGuess.States;

public class NewGameState : IState
{
    private readonly Game game;
    private readonly WordGenerator wordGenerator;
    private readonly IStateFactory stateFactory;

    public NewGameState(Game game, WordGenerator wordGenerator, IStateFactory stateFactory)
    {
        this.game = game;
        this.wordGenerator = wordGenerator;
        this.stateFactory = stateFactory;
    }

    public IView View => null;
    public Interaction Interaction => Interaction.None;

    public IState Act(char? pressedKey)
    {
        game.Word = wordGenerator.Generate();
        return stateFactory.CreateGuessingWordState();
    }
}
