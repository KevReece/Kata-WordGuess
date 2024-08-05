using Moq;
using WordGuess.States;
using WordGuess.Views;

namespace WordGuess.Tests;

public class StateFlowLoopTests
{
    private readonly StateFlowLoop stateFlowLoop;
    private readonly Mock<IStateFactory> stateFactoryMock;
    private readonly Mock<IConsoleWrapper> consoleMock;
    private readonly Mock<IState> startStateMock;
    private readonly Mock<IState> secondStateMock;
    private readonly Mock<IState> thirdStateMock;
    private readonly Mock<IView> viewMock;

    public StateFlowLoopTests()
    {
        stateFactoryMock = new Mock<IStateFactory>();
        consoleMock = new Mock<IConsoleWrapper>();
        startStateMock = new Mock<IState>();
        secondStateMock = new Mock<IState>();
        thirdStateMock = new Mock<IState>();
        viewMock = new Mock<IView>();
        stateFlowLoop = new StateFlowLoop(stateFactoryMock.Object, consoleMock.Object);

        stateFactoryMock.Setup(f => f.CreateNewGameState()).Returns(startStateMock.Object);
        startStateMock.Setup(s => s.Act(It.IsAny<char?>())).Returns(secondStateMock.Object);
        secondStateMock.Setup(s => s.Act(It.IsAny<char?>())).Returns(thirdStateMock.Object);
        secondStateMock.Setup(s => s.View).Returns(viewMock.Object);
        thirdStateMock.Setup(s => s.View).Returns(viewMock.Object);
        viewMock.Setup(v => v.Render()).Returns("View render");
    }
    [Fact]

    public void TestRendersStateView()
    {
        secondStateMock.Setup(s => s.Interaction).Returns(Interaction.Exit);

        stateFlowLoop.Run();

        consoleMock.Verify(c => c.Write("View render"), Times.Once);
    }
    
    [Fact]
    public void TestClearsConsole()
    {
        secondStateMock.Setup(s => s.Interaction).Returns(Interaction.Exit);
        viewMock.Setup(v => v.ClearRender).Returns(true);

        stateFlowLoop.Run();

        consoleMock.Verify(c => c.Clear(), Times.Once);
    }

    [Fact]
    public void TestWaitsForPressAnyKey()
    {
        secondStateMock.Setup(s => s.Interaction).Returns(Interaction.PressAnyKey);
        thirdStateMock.Setup(s => s.Interaction).Returns(Interaction.Exit);

        stateFlowLoop.Run();

        consoleMock.Verify(c => c.ReadKey(), Times.Once);
    }

    [Fact]
    public void TestExitsLoop()
    {
        secondStateMock.Setup(s => s.Interaction).Returns(Interaction.Exit);

        stateFlowLoop.Run();

        secondStateMock.Verify(s => s.Act(It.IsAny<char?>()), Times.Never);
    }

    [Fact]
    public void TestPassesPressedKeyToNextState()
    {
        secondStateMock.Setup(s => s.Interaction).Returns(Interaction.GetKey);
        thirdStateMock.Setup(s => s.Interaction).Returns(Interaction.Exit);
        consoleMock.Setup(c => c.ReadKey()).Returns('a');

        stateFlowLoop.Run();

        secondStateMock.Verify(s => s.Act('a'), Times.Once);
    }
}