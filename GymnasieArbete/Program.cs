using System;
using System.Media;
using Raylib_cs;

bool main = true, startGame = false;

if (main == true)
{
    startGame = MainMenu();
    main = false;
}
if (startGame == true)
{
    Game.StartGame();
}

static bool MainMenu()
{
    //Creates an 800x800 window 
    Raylib.InitWindow(1000, 800, "yes");
    //Sets the targeted fps
    Raylib.SetTargetFPS(60);
    //Makes so you can't close the window by pressing esc
    Raylib.SetExitKey(0);

    Raylib.BeginDrawing();

    Raylib.EndDrawing();

    Raylib.CloseWindow();
    return true;
}