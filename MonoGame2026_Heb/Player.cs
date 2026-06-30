using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame2026_Heb;

public class Player : Sprite
{
    bool IsRKeyPressed = false;
    float speedRotation = 0;
    float speedMovement = 300;

    public Player() : base("pacman")
    {
    }

    public override void Start()
    {
        base.Start();
        
        tm.position = Game1._screenCenter;
        tm.scale = new Vector2(0.3f, 0.3f);
    }

    public override void Update(GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        
        if (Keyboard.GetState().IsKeyDown(Keys.R) && !IsRKeyPressed)
        {
            // R was pressed in this frame
            speedRotation = 500;
       }
        
        if (Keyboard.GetState().IsKeyDown(Keys.D))
        {
            effects = SpriteEffects.None;
            tm.position += new Vector2(speedMovement * deltaTime, 0);
        }
        
        if (Keyboard.GetState().IsKeyDown(Keys.A))
        {
            effects = SpriteEffects.FlipHorizontally;
            tm.position += new Vector2(-speedMovement * deltaTime, 0);
        }
        
        if (Keyboard.GetState().IsKeyDown(Keys.S))
        {
            tm.position += new Vector2(0, speedMovement * deltaTime);
        }
        
        if (Keyboard.GetState().IsKeyDown(Keys.W))
        {
            tm.position += new Vector2(0, -speedMovement * deltaTime);
        }

        IsRKeyPressed =  Keyboard.GetState().IsKeyDown(Keys.R);
        
        tm.rotation = (float)gameTime.TotalGameTime.TotalSeconds * speedRotation;

    } 
}