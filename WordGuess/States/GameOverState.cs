using WordGuess.Models;
using WordGuess.Views;

namespace WordGuess.States;

public class GameOverState : IState
{
    private Game game;

    public GameOverState(Game game)
    {
        this.game = game;
    }

    public IView View => new GameOverView(game);
    public IState Act(char? pressedKey) => null!;
    public Interaction Interaction => Interaction.Exit;
}
