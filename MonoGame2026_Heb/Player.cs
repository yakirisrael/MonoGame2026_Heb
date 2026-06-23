using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGame2026_Heb;

public class Player : Sprite
{
    bool IsRKeyPressed = false;
    float speed = 0;
    
    public override void Start()
    {
       
    }

    public override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.R) && !IsRKeyPressed)
        {
            // R was pressed in this frame
            speed = 500;
       }

        IsRKeyPressed =  Keyboard.GetState().IsKeyDown(Keys.R);
        
        tm.rotation = (float)gameTime.TotalGameTime.TotalSeconds * speed;

    } 
}