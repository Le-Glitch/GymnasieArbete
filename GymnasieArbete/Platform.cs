using System.Drawing;
using System;
using System.Collections.Generic;
using Raylib_cs;

public class Platform
{
    public List<Raylib_cs.Rectangle> platforms = new List<Raylib_cs.Rectangle>();
    
    public void SetPlaforms()
    {
        platforms.AddRange(new List<Raylib_cs.Rectangle>()
        {
            new Raylib_cs.Rectangle(0, Raylib.GetScreenHeight() - 100, Raylib.GetScreenWidth(), 100)
        }
        );
    }

    public void Draw()
    {
        foreach(Raylib_cs.Rectangle platform in platforms)
        {
            Raylib.DrawRectangleRec(platform, Raylib_cs.Color.WHITE);
        }
    }
}
