using System;
using System.Media;
using Raylib_cs;

bool main = true, startGame = false;

if(main == true)
{
    startGame = MainMenu();
    main = false;
}
if(startGame == true)
{
    Game.StartGame();
}

static bool MainMenu()
{
    return true;
}