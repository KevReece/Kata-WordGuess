namespace WordGuess.States;

public interface IStateFactory
{
    IState CreateNewGameState();
    IState CreateGuessingWordState();
    IState CreateGameOverState();
    IState CreateEnteringInitialsState();
}