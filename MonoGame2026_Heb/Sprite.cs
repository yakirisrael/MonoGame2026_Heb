using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame2026_Heb;

public class Sprite : IUpdatable, IDrawable
{
    public Transform tm = new Transform();
    public Texture2D texture;
    public Color color = Color.White;
    public int sortingOrder = 0;
    public SpriteEffects effects = SpriteEffects.None;
    
    public virtual void Start()
    {
       
    }

    public virtual void Update(GameTime gameTime)
    {
       
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(
            texture, 
            tm.position, 
            null,
            color,
            MathHelper.ToRadians(tm.rotation),
            new Vector2(texture.Width * 0.5f, texture.Height * 0.5f),
            tm.scale,
            effects,
            sortingOrder
        );
    }
}