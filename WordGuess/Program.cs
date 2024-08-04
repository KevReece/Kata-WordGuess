
using WordGuess;
using Autofac;

var container = DependencyContainer.Build();

var gameLoop = container.Resolve<GameLoop>();
gameLoop.Run();
