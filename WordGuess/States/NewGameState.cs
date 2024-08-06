using WordGuess.Model;
using WordGuess.Models;
using WordGuess.Views;

namespace WordGuess.States;

public class NewGameState : IState
{
    private readonly GameModel gameModel;
    private readonly WordGenerator wordGenerator;
    private readonly IStateFactory stateFactory;

    public NewGameState(GameModel gameModel, WordGenerator wordGenerator, IStateFactory stateFactory)
    {
        this.gameModel = gameModel;
        this.wordGenerator = wordGenerator;
        this.stateFactory = stateFactory;
    }

    public IView View => new NewGameView();
    public Interaction Interaction => Interaction.PressAnyKey;

    public IState Act(char? pressedKey)
    {
        if (string.IsNullOrEmpty(gameModel.Word))
        {
            gameModel.Word = wordGenerator.Generate();
            return this;
        }
        return stateFactory.CreateGuessingWordState();
    }
}
