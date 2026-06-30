using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame2026_Heb.Content;

public class SpriteManager
{
    static Dictionary<string, Spritesheet> sprites = new Dictionary<string, Spritesheet>();

    private static ContentManager _content;

    public SpriteManager(ContentManager Content)
    {
        _content = Content;
    }

    public static void AddSprite(string spriteName, string fileName,
        int columns = 1, int rows = 1)
    {
        sprites[spriteName] = new Spritesheet();
        sprites[spriteName].texture = _content.Load<Texture2D>(fileName);
        sprites[spriteName].columns = columns;
        sprites[spriteName].rows = rows;
    }

    public static Spritesheet GetSprite(string spriteName)
    {
        if (sprites.ContainsKey(spriteName))
            return sprites[spriteName];
        
        return null;
    }
}