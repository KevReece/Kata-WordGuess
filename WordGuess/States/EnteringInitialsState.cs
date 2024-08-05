using System.Net.Http.Json;
using ScoresApi.Client;
using WordGuess.Models;
using WordGuess.Views;

namespace WordGuess.States;

public class EnteringInitialsState : IState
{
    private Game game;
    private IScoresApiClient scoresApiClient;

    public EnteringInitialsState(Game game, IScoresApiClient scoresApiClient)
    {
        this.game = game;
        this.scoresApiClient = scoresApiClient;
    }

    public IView View => game.PlayerInitials.Length == 0
        ? new StartEnteringInitialsView(game)
        : new EnteringInitialsView();
    public Interaction Interaction => Interaction.GetKey;

    public IState Act(char? pressedKey)
    {
        if (pressedKey.HasValue && char.IsLetter(pressedKey.Value))
        {
            game.PlayerInitials += char.ToUpperInvariant(pressedKey.Value);
        }
        if (game.PlayerInitials.Length < 3)
        {
            return this;
        }
        game.TopScores = GetUpdatedTopScores(game.PlayerInitials, game.WordsComplete)!.Result;
        return new GameOverState(game);
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
