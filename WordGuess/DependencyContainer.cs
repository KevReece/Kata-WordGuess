namespace WordGuess;

using Autofac;
using WordGuess.Model;
using WordGuess.Models;

public class DependencyContainer
{
    public static IContainer Build()
    {
        var containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterType<ConsoleWrapper>().AsSelf();
        containerBuilder.RegisterType<StateFlow>().AsSelf();
        containerBuilder.RegisterType<GameLoop>().AsSelf();
        containerBuilder.RegisterType<StateFactory>().AsSelf();
        containerBuilder.RegisterType<WordGenerator>().AsSelf();
        containerBuilder.RegisterType<Game>().AsSelf();
        return containerBuilder.Build();
    }
}