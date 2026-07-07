using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame2026_Heb;

public class SceneManager : IUpdatable, IDrawable
{
    private static List<IUpdatable> _updatables = new();
    static List<IDrawable> _drawables = new();

    private static SceneManager instance = null;

    public static T Create<T>()  where T : new()
    {
        T obj = new T();
        
        if (obj is IUpdatable updatable)
        {
            _updatables.Add(updatable);
        }
        if (obj is IDrawable drawable)
        {
            _drawables.Add(drawable);
        }
        
        return obj;
    }

    public static void Remove<T>(T obj)
    {
        if (obj is IUpdatable updatable)
        {
            _updatables.Remove(updatable);
        }
        if (obj is IDrawable drawable)
        {
            _drawables.Remove(drawable);
        }
    }

    public static SceneManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SceneManager();
            }

            return instance;
        }
    }

    public void Start()
    {
        foreach (IUpdatable updatable in _updatables)
        {
            updatable.Start();
        }
    }

    public void Update(GameTime gameTime)
    {
        foreach (IUpdatable updatable in _updatables)
        {
            updatable.Update(gameTime);
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (var drawable in _drawables)
        {
            drawable.Draw(spriteBatch);
        }
    }
}