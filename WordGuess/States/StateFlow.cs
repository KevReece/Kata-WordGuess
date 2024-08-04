using WordGuess.States;

namespace WordGuess;

public class StateFlow
{
    public char? PressedKey { get; set; }

    private IState state;

    public StateFlow(StateFactory stateFactory)
    {
        state = stateFactory.CreateNewGameState();
    }

    public IState Step()
    {
        state = state.Act(PressedKey);
        PressedKey = null;
        return state;
    }
}
