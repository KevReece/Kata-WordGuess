namespace WordGuess.Views;

public class EnteringInitialsView : IView
{
    public bool ClearRender { get; private set; } = false;

    public string Render()
    {
        return string.Empty;
    }
}