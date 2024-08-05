using WordGuess;

namespace WordGuess.Views
{
    public interface IView
    {
        bool ClearRender { get; }

        string Render();
    }
}