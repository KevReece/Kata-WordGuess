namespace WordGuess;

public class GameLoop
{
    private readonly StateFlow stateFlow;
    private readonly ConsoleWrapper console;

    public GameLoop(StateFlow stateFlow, ConsoleWrapper console)
    {
        this.stateFlow = stateFlow;
        this.console = console;
    }

    public void Run()
    {
        while (true)
        {
            var state = stateFlow.Step();
            if (state.View.ClearRender)
            {
                console.Clear();
            }
            console.Write(state.View.Render());
            if (state.Interaction == Interaction.GetKey)
            {
                stateFlow.PressedKey = console.ReadKey();
            }
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
