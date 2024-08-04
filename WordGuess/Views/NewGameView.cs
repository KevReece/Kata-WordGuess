namespace WordGuess.Views;

public class NewGameView : IView
{
    public bool ClearRender { get; private set; } = true;

    public string Render()
    {
        return
            "WORD GUESS" + Environment.NewLine +
            "==========" + Environment.NewLine;
    }
}