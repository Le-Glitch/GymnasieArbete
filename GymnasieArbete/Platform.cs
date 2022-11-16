using System;
using Raylib_cs;

public class Platform
{
    public List<Rectangle> platforms = new List<Rectangle>();
    public Rectangle nextScreen = new Rectangle();
    public int screen = 1;
    public bool playerAtStart;

    //Furthest possible jump: 345 pixels
    public void SetPlaforms()
    {
        platforms.AddRange(new List<Rectangle>()
        {
            new Rectangle(0, Raylib.GetScreenHeight() - 100, Raylib.GetScreenWidth(), 100),
            new Rectangle(100, Raylib.GetScreenHeight() - 550, 100, 50),
            new Rectangle(100, Raylib.GetScreenHeight() - 300, 100, 50),
            new Rectangle(0, 375, 100, 50),
            new Rectangle(0, 625, 100, 100),
            new Rectangle(500, 250, 200, 50),
            new Rectangle(Raylib.GetScreenWidth() - 200, 200, 200, 50),
            new Rectangle(900, 200, 200, 50)
        }
        );

    }

    public void Draw()
    {
        foreach (Rectangle platform in platforms)
        {
            Raylib.DrawRectangleRec(platform, Color.WHITE);
        }
    }
}
