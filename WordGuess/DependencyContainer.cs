namespace WordGuess;

using Autofac;
using WordGuess.Model;
using WordGuess.Models;
using WordGuess.States;

public class DependencyContainer
{
    public static IContainer Build()
    {
        var containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterType<ConsoleWrapper>().As<IConsoleWrapper>();
        containerBuilder.RegisterType<StateFlowLoop>().AsSelf();
        containerBuilder.RegisterType<StateFactory>().As<IStateFactory>();
        containerBuilder.RegisterType<WordGenerator>().AsSelf();
        containerBuilder.RegisterType<Game>().AsSelf();
        return containerBuilder.Build();
    }
}