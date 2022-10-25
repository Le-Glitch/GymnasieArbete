using System;
using System.Media;
using Raylib_cs;


public class Game
{
    public static void StartGame()
    {
        //Creates and 800x800 window 
        Raylib.InitWindow(800, 800, "yes");
        //Sets the targeted fps
        Raylib.SetTargetFPS(60);
        //Makes so you can't close the window by accidentally pressing esc
        Raylib.SetExitKey(0);
        //Initiates Raylib's audio system
        Raylib.InitAudioDevice();
        //Sets the general volume
        Raylib.SetMasterVolume(0.3f);

        Music gameMusic = Raylib.LoadMusicStream("music.wav");

        Raylib.SetMusicVolume(gameMusic, 0.75f);

        Raylib.PlayMusicStream(gameMusic);

        Player player = new Player();
        Platform platform = new Platform();

        while (!Raylib.WindowShouldClose())
        {
            player.HorizontalMovement();
            player.VerticleMovement();

            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLACK);

            player.Draw();
            platform.Draw();

            Raylib.EndDrawing();

            Raylib.UpdateMusicStream(gameMusic);
        }
    }
}
