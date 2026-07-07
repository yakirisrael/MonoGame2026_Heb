using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame2026_Heb;

public class Collider : Sprite
{
    public bool IsTrigger = false;
    public int thickness;

    public Sprite Parent { get; set; }

    public Collider() : base("Pixel")
    {
    }

    public override void Draw(SpriteBatch _spriteBatch)
    {
#if DEBUG
        // draw outline bounds
        
        color = Color.Green;
        thickness = 5;
        
        _spriteBatch.Draw(
            texture,
            new Rectangle(Parent.destRect.X, Parent.destRect.Y, Parent.destRect.Width, thickness), // top
            color);

        _spriteBatch.Draw(
            texture,
            new Rectangle(Parent.destRect.X, Parent.destRect.Y, thickness, Parent.destRect.Height), // left
            color);

        _spriteBatch.Draw(
            texture,
            new Rectangle(Parent.destRect.X + Parent.destRect.Width - thickness, Parent.destRect.Y, thickness, Parent.destRect.Height), // right
            color);

        _spriteBatch.Draw(
            texture,
            new Rectangle(Parent.destRect.X, Parent.destRect.Y + Parent.destRect.Height - thickness, Parent.destRect.Width, thickness), // bottom
            color);
        
#endif
    }
}