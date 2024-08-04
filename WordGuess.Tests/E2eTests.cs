using System.Diagnostics;

namespace WordGuess.Tests;

public class E2eTests
{
    [Fact]
    public async Task TestConsoleAppLoads()
    {
        using var consoleProcess = GetWordGuessConsoleProcess();

        var output = await GetAllConsoleOutput(consoleProcess);
        Assert.Contains("WORD GUESS", output);
    }

    private static Process GetWordGuessConsoleProcess()
    {
        var consoleAppPath = @"..\..\..\..\WordGuess\bin\Debug\net6.0\WordGuess.exe";

        var processStartInfo = new ProcessStartInfo
        {
            FileName = consoleAppPath,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        var consoleProcess = new Process { StartInfo = processStartInfo };
        consoleProcess.Start();
        return consoleProcess;
    }

    private async static Task<string> GetAllConsoleOutput(Process consoleProcess)
    {
        var outputTask = consoleProcess.StandardOutput.ReadToEndAsync();
        if (!consoleProcess.WaitForExit(1000)) 
        {
            consoleProcess.Kill();
        }
        return await outputTask;
    }
}
