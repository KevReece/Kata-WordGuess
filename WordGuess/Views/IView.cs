using WordGuess;

public interface IView
{
    bool ClearRender { get; }

    string Render();
}