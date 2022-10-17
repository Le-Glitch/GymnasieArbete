﻿using System;
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
    //Creates and 800x800 window 
    Raylib.InitWindow(1920, 1080, "yes");
    //Sets the targeted fps
    Raylib.SetTargetFPS(60);
    //Makes so you can't close the window by accidentally pressing esc
    Raylib.SetExitKey(0);

    


    return true;
}