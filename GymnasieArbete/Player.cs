using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

public class Player
{
    float gravity;
    public Texture2D playerTexture;

    public Vector2 position;
    Vector2 speed = new Vector2(0, 10);
    public Rectangle playerRect;

    bool collisionCheckHor = false;
    bool collisionCheckVer = false;
    bool isJumping = false;
    string direction = "right";

    public void HorizontalMovement()
    {
        if(Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        {
            position.X += speed.X;
        }
        if(Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            position.X -= speed.X;
        }
    }

    public void VerticleMovement()
    {
        
    }

    public void Draw()
    {

    }
}
