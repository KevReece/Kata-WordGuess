
namespace WordGuess;

public interface IConsoleWrapper
{
    void Clear();
    void Write(string value);
    char ReadKey();
}