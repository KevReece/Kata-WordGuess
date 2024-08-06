using System.Net.Http.Json;
using ScoresApi.Client;
using WordGuess.Models;
using WordGuess.Views;

namespace WordGuess.States;

public class EnteringInitialsState : IState
{
    private GameModel gameModel;
    private IScoresApiClient scoresApiClient;

    public EnteringInitialsState(GameModel gameModel, IScoresApiClient scoresApiClient)
    {
        this.gameModel = gameModel;
        this.scoresApiClient = scoresApiClient;
    }

    public IView View => gameModel.PlayerInitials.Length == 0
        ? new StartEnteringInitialsView(gameModel)
        : new EnteringInitialsView();
    public Interaction Interaction => Interaction.GetKey;

    public IState Act(char? pressedKey)
    {
        if (pressedKey.HasValue && char.IsLetter(pressedKey.Value))
        {
            gameModel.PlayerInitials += char.ToUpperInvariant(pressedKey.Value);
        }
        if (gameModel.PlayerInitials.Length < 3)
        {
            return this;
        }
        gameModel.TopScores = GetUpdatedTopScores(gameModel.PlayerInitials, gameModel.WordsComplete)!.Result;
        return new GameOverState(gameModel);
    }

    private async Task<IEnumerable<Tuple<string, int>>>? GetUpdatedTopScores(string playerInitials, int wordsComplete)
    {
        var postResponse = await scoresApiClient.PostScoreAsync(playerInitials, wordsComplete);
        if (!postResponse.IsSuccessStatusCode)
        {
            throw new InvalidOperationException("Failed to post score.");
        }
        var getResponse =  await scoresApiClient.GetTopScoresAsync();
        if (!getResponse.IsSuccessStatusCode)
        {
            throw new InvalidOperationException("Failed to get top scores.");
        }
        var scores = await getResponse.Content.ReadFromJsonAsync<IEnumerable<Score>>();
        if (scores is null)
        {
            throw new InvalidOperationException("Failed to parse top scores.");
        }
        var orderedTopTenScores = scores.Select(score => Tuple.Create(score.Name, score.Value));
        return orderedTopTenScores;
    }
}
