Context
===
User state flow 
- display new game
- display guessing word <
    - input letter ^
- display score <
    - input initial ^
- game over (top scores)

Containers
===
- WordGuess - Console .Net 
- ScoresApi - Rest WebApi .Net
- ScoresDb - Redis

Components
===

WordGuess
- StateFlowLoop - Progresses states, renders views, applies interactions
- GameModel - Models all the game values
- States:{NewGame/GuessingWord/EnteringInitials/GameOver}
- Views:{NewGame/GuessingWord/StartEnteringInitials/EnteringInitials/GameOver}
- WordGenerator - for each new word

ScoresApi
- ScoresApiClient - separate library as API SDK
- ScoresRepository - connects to ScoresDB

ScoresDB
- `scores` list

Code
===

WordGuess
- Game
    - string Word
    - string MaskedWord
    - int Points
    - int CurrentCharIndex
    - string PlayerInitials
    - int WordsComplete
    - array(string player, int score) TopScores

ScoresApi
    - POST `/score` (string player, int score)
    - GET `/topscores` (array(string player, int score))

ScoresDB
- scores
    - sorted set: 
        - DateTime Date
        - string Name
        - int Value
