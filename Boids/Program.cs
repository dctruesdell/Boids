using System;

internal class Program
{
    private static void Main()
    {
        using var game = new Boids.Game1();
        game.Run();
    }
}

