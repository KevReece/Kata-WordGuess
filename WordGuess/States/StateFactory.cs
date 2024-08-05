using WordGuess.Model;
using WordGuess.Models;

namespace WordGuess.States;

public class StateFactory : IStateFactory
{
    private readonly WordGenerator wordGenerator;
    private readonly Game game;

    public StateFactory(WordGenerator wordGenerator, Game game)
    {
        this.wordGenerator = wordGenerator;
        this.game = game;
    }

    public IState CreateNewGameState()
    {
        return new NewGameState(game, wordGenerator, this);
    }

    public IState CreateGuessingWordState()
    {
        return new GuessingWordState(game, wordGenerator, this);
    }

    public IState CreateGameOverState()
    {
        return new GameOverState(game);
    }

    public IState CreateEnteringInitialsState()
    {
        return new EnteringInitialsState(game);
    }
}
