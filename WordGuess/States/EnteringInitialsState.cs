using WordGuess.Models;
using WordGuess.States;
using WordGuess.Views;

namespace WordGuess;

public class EnteringInitialsState : IState
{
    private Game game;

    public EnteringInitialsState(Game game)
    {
        this.game = game;
    }

    public IView View => game.PlayerInitials.Length == 0 
        ? new StartEnteringInitialsView(game) 
        : new EnteringInitialsView();
    public Interaction Interaction => Interaction.GetKey;

    public IState Act(char? pressedKey)
    {
        if (pressedKey.HasValue && char.IsLetter(pressedKey.Value))
        {
            game.PlayerInitials += char.ToUpperInvariant(pressedKey.Value);
        }
        if (game.PlayerInitials.Length < 3)
        {
            return this;
        }
        return new GameOverState(game);
    }
}
