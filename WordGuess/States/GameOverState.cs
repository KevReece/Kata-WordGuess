using WordGuess.Models;
using WordGuess.States;

namespace WordGuess;

public class GameOverState : IState
{
    private Game game;

    public GameOverState(Game game)
    {
        this.game = game;
    }

    public IView View => new GameOverView(game);
    public IState Act(char? pressedKey) => this;
    public Interaction Interaction => Interaction.Exit;
}
