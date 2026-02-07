using System.Diagnostics;

namespace Number_Guessing_Game.App;

class Program
{
    private static Level _easy = new Level(DifficultyLevels.Easy);
    private static Level _medium = new Level(DifficultyLevels.Medium);
    private static Level _hard = new Level(DifficultyLevels.Hard);
    private readonly static Random _random = new Random();
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Number Guessing Game!\nI'm thinking of a integer number between 1 and 100.\nYou have number of chances to guess the correct number.\n\n");

        while (true)
        {
            Console.WriteLine("Please select the difficulty level:\n1. Easy (10 chances)\n2. Medium (5 chances)\n3. Hard (3 chances)");
            Console.WriteLine();
            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int userChoice))
            {
                Console.WriteLine();
                SetDifficultyLevel(userChoice, out Level difficulty);
                if (difficulty == null)
                    continue;
                PlayGame(difficulty);
                if (PlayAgain())
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("GoodBye!!!");
                    break;
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid Format");
                continue;
            }
        }
    }

    private static void SetDifficultyLevel(int userChoice, out Level difficulty)
    {
        if (userChoice == 1)
        {
            difficulty = _easy;
        }
        else if (userChoice == 2)
        {
            difficulty = _medium;
        }
        else if (userChoice == 3)
        {
            difficulty = _hard;
        }
        else
        {
            difficulty = null;
            Console.WriteLine("Invalid Value");
            Console.WriteLine();
        }
    }

    private static void PlayGame(Level difficulty)
    {
        int generatedNumber = _random.Next(1, 101);
        int attemptsNumber = 1;
        int tries = difficulty.Chances;

        Console.WriteLine($"Great! You have selected the {difficulty.Name} difficulty level.");
        if (!difficulty.IsFirstTime)
            Console.WriteLine($"High Score For {difficulty.Name} Level = {difficulty.HighScore}.");
        else
            Console.WriteLine($"High Score For {difficulty.Name} Level = nan.");
        Console.WriteLine("Let's start the game!");

        while (tries > 0)
        {
            Stopwatch timer = Stopwatch.StartNew();
            Console.Write("Enter your guess: ");
            if (int.TryParse(Console.ReadLine(), out int guessNumber))
            {
                if (guessNumber < generatedNumber)
                {
                    Console.WriteLine($"Incorrect! The number is greater than {guessNumber}.");
                }
                else if (guessNumber > generatedNumber)
                {
                    Console.WriteLine($"Incorrect! The number is less than {guessNumber}.");
                }
                else
                {
                    timer.Stop();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Congratulations! You guessed the correct number in {attemptsNumber} attempts.");
                    Console.WriteLine($"Time taken: {timer.Elapsed.TotalSeconds:f2} seconds.");
                    difficulty.UpdateHighScore(attemptsNumber);
                    Console.ResetColor();
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid Input");
                continue;
            }
            tries--;
            attemptsNumber++;
        }
        if (tries == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Game Over! The number was {generatedNumber}.");
            Console.ResetColor();
        }
    }
    private static bool PlayAgain()
    {
        Console.Write("Do You Wanna Play Again?(y/n): ");
        string playAgain = Console.ReadLine();
        if (!string.IsNullOrEmpty(playAgain))
            playAgain = playAgain.ToLower();
        else
            playAgain = "";
        return playAgain == "y" || playAgain.StartsWith('y');
    }
}