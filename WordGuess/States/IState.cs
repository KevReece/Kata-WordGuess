namespace WordGuess.States;

public interface IState
{
    IState Act(char? pressedKey);
    IView View { get; }
    Interaction Interaction { get; }
}