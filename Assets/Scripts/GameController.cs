public static class GameController
{
    private static int lives;
    private static int coinsCollected;
    public static int CoinsCollected => coinsCollected;
    
    public static float Timer { get; private set; } 
    public static bool IsTimerRunning { get; private set; } 
    public static int Lives => lives;

    public static bool GameOver => lives <= 0;
    
    public static void Init()
    {
        coinsCollected = 0;
        lives = 3;
        Timer = 0f; 
        IsTimerRunning = true; 
    }

    public static void Collect()
    {
        coinsCollected++;
        
        if (coinsCollected % 15 == 0)
        {
            lives++;
        }
    }
    public static void LoseLife()
    {
        if (lives > 0) lives--;
        
        
        if (lives <= 0) 
        {
            IsTimerRunning = false;
        }
    }
    public static void TickTimer(float deltaTime)
    {
        if (IsTimerRunning)
        {
            Timer += deltaTime;
        }
    }
}