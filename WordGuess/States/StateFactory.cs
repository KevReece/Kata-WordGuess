using ScoresApi.Client;
using WordGuess.Model;
using WordGuess.Models;

namespace WordGuess.States;

public class StateFactory : IStateFactory
{
    private readonly WordGenerator wordGenerator;
    private readonly GameModel gameModel;
    private readonly IScoresApiClient scoresApiClient;

    public StateFactory(WordGenerator wordGenerator, GameModel gameModel, IScoresApiClient scoresApiClient)
    {
        this.wordGenerator = wordGenerator;
        this.gameModel = gameModel;
        this.scoresApiClient = scoresApiClient;
    }

    public IState CreateNewGameState()
    {
        return new NewGameState(gameModel, wordGenerator, this);
    }

    public IState CreateGuessingWordState()
    {
        return new GuessingWordState(gameModel, wordGenerator, this);
    }

    public IState CreateGameOverState()
    {
        return new GameOverState(gameModel);
    }

    public IState CreateEnteringInitialsState()
    {
        return new EnteringInitialsState(gameModel, scoresApiClient);
    }
}
