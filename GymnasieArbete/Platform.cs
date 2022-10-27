using System;
using Raylib_cs;

public class Platform
{
    public List<Rectangle> platforms = new List<Rectangle>();
    public Rectangle nextScreen = new Rectangle();
    public int screen = 1;
    public bool playerAtStart;

    public void SetPlaforms()
    {
        platforms.AddRange(new List<Rectangle>()
        {
            new Rectangle(0, Raylib.GetScreenHeight() - 100, Raylib.GetScreenWidth(), 100),
            new Rectangle(0, Raylib.GetScreenHeight() - 250, 200, 150),
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
