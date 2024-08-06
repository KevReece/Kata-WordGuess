Concept
===
- Start with first letter of random word
- Guess next letter
- Get penalties for ordinal distance to letter
- Start with 100 points.
- Gain 10 points per new word
- Store high scores against 3 letter name
- Generic high scores (backend and db)

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
- WordGuess - Console .net 
- ScoresApi - Rest webapi .net
- ScoresDb - redis

Components
===

WordGuess
- StateFlowLoop - Progresses states, renders views, applies interactions
- Game - Holds the game values
- States:{NewGame/GuessingWord/EnteringInitials/GameOver}
- View:{NewGame/GuessingWord/StartEnteringInitials/EnteringInitials/GameOver}
- WordGenerator

ScoresApi
- ScoresRepository

ScoresDB
- scores

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
    - POST score (string player, int score)
    - GET topscores (array(string player, int score))

ScoresDB
- scores
    - sorted set: 
        - DateTime Date
        - string Name
        - int Value
