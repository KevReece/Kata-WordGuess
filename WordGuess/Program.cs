
using WordGuess;
using Autofac;

var container = DependencyContainer.Build();

var stateFlowLoop = container.Resolve<StateFlowLoop>();
stateFlowLoop.Run();
