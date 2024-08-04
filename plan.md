Concept
===
Start with first letter of random word
Guess next letter
Get penalties for ordinal distance to letter
Start with 100 points.
Gain 10 points per new word
Store high scores against 3 letter name
Generic high scores backend and db

Context
===
User state flow 
- display game start
- display word start <
- display state <
- input letter ^
- display result
- input initials
- display top scores

Containers
===
- WordGuess - Console .net 
- ScoresApi - Rest webapi .net
- ScoresDb - redis

Components
===
WordGuess
- GameStateFlow
- Game
- {GameStart/WordStart/...}StateView
- WordGenerator
- ScoresApiClient

ScoresApi
- ScoresController
- ScoresRepository
