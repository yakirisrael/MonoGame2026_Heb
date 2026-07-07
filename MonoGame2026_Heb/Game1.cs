using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame2026_Heb.Content;

namespace MonoGame2026_Heb;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D _logo;
    Texture2D _pongAtlas;
    
    public static Vector2 _screenCenter;

    private Player player = null;
    private Enemy enemy = null;

    private SpriteFont _fontOswald;
    
    MousePositionText mousePositionText = new MousePositionText();
    private SpriteManager spriteManager = null;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        spriteManager = new SpriteManager(Content);
        
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.PreferredBackBufferHeight = 1080;

        _graphics.IsFullScreen = true;
        
        _screenCenter =  new Vector2(
            _graphics.PreferredBackBufferWidth * 0.5f,
            _graphics.PreferredBackBufferHeight * 0.5f);

    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        SpriteManager.AddSprite("orangeBird","Images/Bird1_1", 4,4);
        SpriteManager.AddSprite("duck","Images/Bird2 Duck_1", 4,4);
        SpriteManager.AddSprite("egret","Images/Bird3_Egret4", 4,4);
        SpriteManager.AddSprite("Pixel","Images/pixel");
        
//        _pongAtlas =  Content.Load<Texture2D>("Images/pong-atlas");
 
        mousePositionText.font = Content.Load<SpriteFont>("Fonts/Oswald");
        
        Start();

        // TODO: use this.Content to load your game content here
    }

    void Start()
    {
        player = SceneManager.Create<Player>();
        player.PlayAnimation();
        
        
        enemy = SceneManager.Create<Enemy>();
        enemy.PlayAnimation();
        
        SceneManager.Instance.Start();

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        

        SceneManager.Instance.Update(gameTime);
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.DarkRed);

        _spriteBatch.Begin();

        SceneManager.Instance.Draw(_spriteBatch);
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}