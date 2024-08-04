using WordGuess.Model;
using WordGuess.Models;
using WordGuess.States;
using WordGuess.Views;

namespace WordGuess;

public class NewGameState : IState
{
    private readonly Game game;
    private readonly WordGenerator wordGenerator;
    private readonly StateFactory stateFactory;

    public NewGameState(Game game, WordGenerator wordGenerator, StateFactory stateFactory)
    {
        this.game = game;
        this.wordGenerator = wordGenerator;
        this.stateFactory = stateFactory;
    }

    public IView View => new NewGameView();
    public Interaction Interaction => Interaction.GetKey;

    public IState Act(char? pressedKey)
    {
        game.Word = wordGenerator.Generate();
        return stateFactory.CreateGuessingWordState();
    }
}
