namespace Number_Guessing_Game.App;

internal class Level
{
    public DifficultyLevels Name { get; init; }
    public int Chances { get; }
    public int HighScore { get; private set; } = int.MaxValue;
    public bool IsFirstTime { get; private set; } = true;

    public Level(DifficultyLevels name)
    {
        Name = name;
        Chances = (int)Name;
    }
    public void UpdateHighScore(int attemptsNumber)
    {
        if (attemptsNumber < HighScore)
        {
            HighScore = attemptsNumber;
            IsFirstTime = false;
            Console.WriteLine($"WOW! New High Score in {Name}.");
        }
    }
}