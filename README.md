> # Number Guessing Game 🎮
## Description
A simple, interactive console-based number guessing game built with **C#**. This project is inspired by the [roadmap.sh](https://roadmap.sh/projects/number-guessing-game) project ideas.

## Features
* **Difficulty Levels:** Choose between Easy, Medium, and Hard.
* **Dynamic Chances:** Each level gives you a specific number of attempts.
* **High Score Tracking:** The game remembers your best (lowest) score for each difficulty during the session.
* **Input Validation:** Handles non-integer inputs and decimals gracefully without wasting your turns.
* **Replayability:** Option to restart the game and clear the console after each round.

## How to Play
1. **Run the application.**
2. **Select Difficulty:** Enter `1`, `2`, or `3` to set your chances.
3. **Guess the Number:** Enter a whole number between **1 and 100**.
4. **Follow Hints:** The game will tell you if the secret number is *greater* or *less* than your guess.
5. **Win or Lose:** Try to beat the High Score!

## Difficulty Table
| Level | Chances |
| --- | --- |
| **Easy** | 10 |
| **Medium** | 5 |
| **Hard** | 3 |

## Future Enhancements
* [ ] Save high scores to a local file (`.txt` or `.json`).
* [ ] Add a timer to track how fast the user guesses.