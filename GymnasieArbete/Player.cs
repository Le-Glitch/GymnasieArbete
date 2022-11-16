using System.IO;
using System;
using System.Numerics;
using Raylib_cs;

public class Player
{
    float gravity;
    public Texture2D playerTexture = Raylib.LoadTexture("player-right.png");

    Texture2D playerRight = Raylib.LoadTexture("player-right.png");
    Texture2D playerLeft = Raylib.LoadTexture("player-left.png");

    public Vector2 position;
    Vector2 speed = new Vector2(0, 10);

    bool collisionCheckHor = false;
    bool collisionCheckVer = false;
    bool isJumping = false;
    string direction = "right";

    public void characterDirection()
    {
        //Changes the direction that the character is facing by replacing the texture
        if (direction == "right")
        {
            playerTexture = playerRight;
        }
        if (direction == "left")
        {
            playerTexture = playerLeft;
        }
    }

    public void HorizontalMovement()
    {
        speed.X = 0;
        //Moves the player to the right if the right arrow key is pressed down
        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        {
            speed.X = 5;
            direction = "right";
        }
        //Moves the player to the left if the left arrow key is pressed down
        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            speed.X = -5;
            direction = "left";
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
            gravity += 0.33f;
        }
    }

    //Checks for collisions on the x-axis
    public void XCollision(List<Rectangle> platforms)
    {
        //Checks collisions with platforms
        foreach (Rectangle platform in platforms)
        {
            collisionCheckHor = Raylib.CheckCollisionRecs(platform, new Rectangle((int)position.X, (int)position.Y, playerTexture.width, playerTexture.height));
            if (collisionCheckHor)
            {
                position.X -= speed.X;

                break;
            }
        }

        //Checks collisions with the edges of the screen
        if (position.X < 0 || position.X + playerTexture.width > Raylib.GetScreenWidth())
        {
            position.X -= speed.X;
        }
    }

    //Checks for collisions on the y-axis
    public void YCollision(List<Rectangle> platforms)
    {
        //Checks collisions with platforms
        foreach (Rectangle platform in platforms)
        {
            //First checks if there is a collision
            collisionCheckVer = Raylib.CheckCollisionRecs(platform, new Rectangle((int)position.X, (int)position.Y, playerTexture.width, playerTexture.height));
            //Then checks whether the collision is occuring from above or below 
            if (collisionCheckVer)
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

                break;
            }
        }
    }

    public Rectangle UpdatePos()
    {
        return new Rectangle(position.X, position.Y, playerTexture.width, playerTexture.height);
    }

    //Draws the character
    public void Draw()
    {
        Raylib.DrawTexture(playerTexture, (int)position.X, (int)position.Y, Color.WHITE);
    }
}
