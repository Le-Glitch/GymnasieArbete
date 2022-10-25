using System.Drawing;
using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

public class Player
{
    float gravity;
    public Texture2D playerTexture = Raylib.LoadTexture("player-right.png");

    public Vector2 position;
    Vector2 speed = new Vector2(0, 10);

    bool collisionCheckHor = false;
    bool collisionCheckVer = false;
    bool isJumping = false;
    string direction = "right";

    public void HorizontalMovement()
    {
        speed.X = 0;
        //Moves the player to the right if the right arrow key is pressed down
        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        {
            speed.X = 5;
        }
        //Moves the player to the left if the left arrow key is pressed down
        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            speed.X = -5;
        }

        position.X += speed.X;
    }

    public void VerticleMovement()
    {
        //Allows the player to jump if they press the spacebar and aren't in the air
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && !isJumping)
        {
            speed.Y = 10;
            isJumping = true;
        }

        //Makes the player go up if they are jumping
        if (isJumping == true)
        {
            position.Y -= speed.Y;
        }
    }

    public void Gravity()
    {
        //Makes the player fall if they are in the air
        if (position.Y < Raylib.GetScreenHeight() - playerTexture.height)
        {
            position.Y += gravity;
            gravity += 0.25f;
        }
    }

    //Checks for collisions on the x-axis
    public void xCollision(List<Raylib_cs.Rectangle> platforms)
    {
        foreach (Raylib_cs.Rectangle platform in platforms)
        {
            collisionCheckHor = Raylib.CheckCollisionRecs(platform, new Raylib_cs.Rectangle((int)position.X, (int)position.Y, playerTexture.width, playerTexture.height));
            if (collisionCheckHor)
            {
                position.X -= speed.X;

                break;
            }
        }
    }

    //Checks for collisions on the x-axis
    public void yCollision(List<Raylib_cs.Rectangle> platforms)
    {
        foreach (Raylib_cs.Rectangle platform in platforms)
        {
            collisionCheckVer = Raylib.CheckCollisionRecs(platform, new Raylib_cs.Rectangle((int)position.X, (int)position.Y, playerTexture.width, playerTexture.height));
            if (collisionCheckVer)
            {
                if (position.X + playerTexture.width > platform.x && position.X < platform.x + platform.width)
                {
                    if (position.Y + playerTexture.height < platform.y + platform.height / 2)
                    {
                        position.Y = platform.y - playerTexture.height;
                        gravity = 0;
                        isJumping = false;
                    }
                    else if (position.Y > platform.y + platform.height / 2)
                    {
                        position.Y += speed.Y;
                        speed.Y /= 2;
                    }
                }
                break;
            }
        }
    }

    public void Draw()
    {

    }
}
