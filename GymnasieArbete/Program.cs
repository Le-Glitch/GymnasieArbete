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


bool MainMenu()
{
    Menu mainMenu = new Menu();

    //Creates an 800x800 window 
    Raylib.InitWindow(1000, 800, "yes");
    //Sets the targeted fps
    Raylib.SetTargetFPS(60);
    //Makes so you can't close the window by pressing esc
    Raylib.SetExitKey(0);

    while (!Raylib.WindowShouldClose())
    {
    Raylib.BeginDrawing();

    mainMenu.Draw();

    Raylib.EndDrawing();

    Raylib.CloseWindow();    
    }
    return true; 
}