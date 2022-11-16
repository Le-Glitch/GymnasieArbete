using System;
using Raylib_cs;

public class Platform
{
    public List<Rectangle> platforms = new List<Rectangle>();
    public Rectangle nextScreen = new Rectangle();
    public int screen = 1;
    public bool playerAtStart;
    Rectangle nothing = new Rectangle(0, 0, 0, 0);

    //Furthest possible jump: 345 pixels
    public (Rectangle, Rectangle) SetPlaforms()
    {
        platforms.Clear();

        switch(screen){
        case(1):
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

                return (new Rectangle(Raylib.GetScreenWidth(), 0, 1, 200), nothing);
        
        }
        return (nothing, nothing);
    }

    public void Draw()
    {
        foreach (Rectangle platform in platforms)
        {
            Raylib.DrawRectangleRec(platform, Color.WHITE);
        }
    }
}
