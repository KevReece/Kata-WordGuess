using WordGuess.States;

namespace WordGuess;

public class StateFlowLoop
{
    private readonly IStateFactory stateFactory;
    private readonly IConsoleWrapper console;

    public StateFlowLoop(IStateFactory stateFactory, IConsoleWrapper console)
    {
        this.stateFactory = stateFactory;
        this.console = console;
    }

    public void Run()
    {
        var state = stateFactory.CreateNewGameState();
        var pressedKey = null as char?;
        while (true)
        {
            state = state.Act(pressedKey);
            if (state.View.ClearRender)
            {
                console.Clear();
            }
            console.Write(state.View.Render());
            pressedKey = state.Interaction == Interaction.GetKey? console.ReadKey() : null;
            if (state.Interaction == Interaction.PressAnyKey)
            {
                console.ReadKey();
            }
            if (state.Interaction == Interaction.Exit)
            {
                break;
            }
        }
    }
}
