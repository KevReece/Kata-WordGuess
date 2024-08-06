using WordGuess.Models;
using WordGuess.Views;

namespace WordGuess.States;

public class GameOverState : IState
{
    private GameModel gameModel;

    public GameOverState(GameModel gameModel)
    {
        this.gameModel = gameModel;
    }

    public IView View => new GameOverView(gameModel);
    public IState Act(char? pressedKey) => null!;
    public Interaction Interaction => Interaction.Exit;
}
