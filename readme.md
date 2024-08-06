Kata - Word Guess
===

- Display to user first letter of random word.
- User guesses next letter.
- Points penalties for ordinal distance to correct letter.
- Start with 100 points.
- Gain 10 points per new word.
- Game is over when points go below 0.
- Score is number of words completed.
- Store high scores against 3 letter name initials.
- Generic high scores storage (Backend API and DB).

Secondary Objective
---

Demonstrate State-Model-View pattern as console service architecture. 

- This allows for user interaction modelling as state flow to map straight into states implementation.
- This allows the domain modelling to map straight in models implementation.
- This allows for UI modelling to map straight into views implementation.

Application classes:

- `<>State` classes: act on the model, define interaction, view to render, and next state.
- `<>View` classes: build the console output based on the model.
- `<>Model` classes: represent the domain, which the states act on and views render from.

Boilerplate:

- `StateFlowLoop`: progresses between states, and applies their interactions and rendering.
- `Interactions` enum: decouples states from interaction implementation in `StateFlowLoop`.
- `StateFactory`: decouples states from each other.
