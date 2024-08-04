
namespace WordGuess;

public class ConsoleWrapper
{
    public void Clear()
    {
        Console.Clear();
    }

    public void Write(string value)
    {
        Console.Write(value);
    }

    public char ReadKey()
    {
        return Console.ReadKey().KeyChar;
    }
}