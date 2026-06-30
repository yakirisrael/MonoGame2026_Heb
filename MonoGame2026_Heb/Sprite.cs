using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame2026_Heb.Content;

namespace MonoGame2026_Heb;

public class Sprite : IUpdatable, IDrawable
{
    public Transform tm = new Transform();
    public Texture2D texture;
    public Spritesheet spritesheet;
    public Color color = Color.White;
    public int sortingOrder = 0;
    public SpriteEffects effects = SpriteEffects.None;

    private Rectangle? sourceRect = null;
    private Rectangle destRect;
    
    private Vector2 origin = Vector2.Zero;


    public Sprite(string spriteName)
    {
        spritesheet = SpriteManager.GetSprite(spriteName);
    }

    public virtual void Start()
    {

        texture = spritesheet.texture;
        
        sourceRect = texture.Bounds;
        origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
    }

    public virtual void Update(GameTime gameTime)
    {
       
    }

    private Rectangle GetDestRect(Rectangle? srcRect)
    {
        // take into account the scale and origin into 
        // the final result of dest rectangle
        
        if (srcRect == null) return new Rectangle();
        
        int width = (int)(srcRect.Value.Width * tm.scale.X);
        int height = (int)(srcRect.Value.Height * tm.scale.Y);

        int pos_x = (int)(tm.position.X - origin.X * tm.scale.X);
        int pos_y = (int)(tm.position.Y - origin.Y * tm.scale.Y);
        
        return new Rectangle(
            pos_x,
            pos_y,
            width,
            height
            );
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        destRect = GetDestRect(sourceRect);
        
        spriteBatch.Draw(
            texture, 
            destRect,
            sourceRect,
            color,
            MathHelper.ToRadians(tm.rotation),
            origin,
            effects,
            sortingOrder
        );
    }
}