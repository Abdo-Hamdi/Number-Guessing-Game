namespace Number_Guessing_Game.App;

class Program
{
    enum DifficultyLevels
    {
        Easy = 10,
        Medium = 5,
        Hard = 3,
        Default = 0
    }
    private readonly static Random _random = new Random();
    private static int EasyHighScore = int.MaxValue;
    private static int MeduimHighScore = int.MaxValue;
    private static int HardHighScore = int.MaxValue;
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Number Guessing Game!\nI'm thinking of a integer number between 1 and 100.\nYou have number of chances to guess the correct number.\n\n");

        while (true)
        {
            Console.WriteLine("Please select the difficulty level:\n1. Easy (10 chances)\n2. Medium (5 chances)\n3. Hard (3 chances)");
            Console.WriteLine();
            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine();
                SetDifficulty(choice, out DifficultyLevels difficulty);
                if (difficulty == DifficultyLevels.Default)
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

    private static void SetDifficulty(int difficultyLevel, out DifficultyLevels difficulty)
    {
        if (difficultyLevel == 1)
        {
            difficulty = DifficultyLevels.Easy;
        }
        else if (difficultyLevel == 2)
        {
            difficulty = DifficultyLevels.Medium;
        }
        else if (difficultyLevel == 3)
        {
            difficulty = DifficultyLevels.Hard;
        }
        else
        {
            difficulty = DifficultyLevels.Default;
            Console.WriteLine("Invalid Value");
            Console.WriteLine();
        }
    }

    private static void PlayGame(DifficultyLevels difficulty)
    {
        int tries = (int)difficulty;
        Console.WriteLine($"Great! You have selected the {difficulty} difficulty level.");
        if (difficulty == DifficultyLevels.Easy)
        {
            Console.WriteLine($"High Score For {difficulty} Level = {EasyHighScore}");
        }
        else if (difficulty == DifficultyLevels.Medium)
        {
            Console.WriteLine($"High Score For {difficulty} Level = {MeduimHighScore}");
        }
        else
        {
            Console.WriteLine($"High Score For {difficulty} Level = {HardHighScore}");
        }
        Console.WriteLine("Let's start the game!");
        int generatedNumber = _random.Next(1, 101);
        int attemptsNumber = 1;
        while (tries > 0)
        {
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
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Congratulations! You guessed the correct number in {attemptsNumber} attempts.");
                    if (difficulty == DifficultyLevels.Easy)
                    {
                        if (attemptsNumber < EasyHighScore)
                        {
                            EasyHighScore = attemptsNumber;
                            Console.WriteLine($"WOW! New High Score in {DifficultyLevels.Easy}.");
                        }
                    }
                    else if (difficulty == DifficultyLevels.Medium)
                    {
                        if (attemptsNumber < MeduimHighScore)
                        {
                            MeduimHighScore = attemptsNumber;
                            Console.WriteLine($"WOW! New High Score in {DifficultyLevels.Medium}.");
                        }
                    }
                    else
                    {
                        if (attemptsNumber < HardHighScore)
                        {
                            HardHighScore = attemptsNumber;
                            Console.WriteLine($"WOW! New High Score in {DifficultyLevels.Hard}.");
                        }
                    }
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
            playAgain = "n";
        return playAgain == "y" || playAgain.StartsWith('y');
    }
}