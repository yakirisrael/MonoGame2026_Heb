using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGame2026_Heb;

public class Player : Sprite
{
    bool IsRKeyPressed = false;
    float speedRotation = 0;
    float speedMovement = 300;
    
    public override void Start()
    {
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
            tm.position += new Vector2(speedMovement * deltaTime, 0);
        }
        
        if (Keyboard.GetState().IsKeyDown(Keys.A))
        {
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