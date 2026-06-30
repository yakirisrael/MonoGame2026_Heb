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
        
//        _pongAtlas =  Content.Load<Texture2D>("Images/pong-atlas");
 
        mousePositionText.font = Content.Load<SpriteFont>("Fonts/Oswald");
        
        Start();

        // TODO: use this.Content to load your game content here
    }

    void Start()
    {
        player = new Player();
        player.Start();
        player.PlayAnimation();
        
        mousePositionText.Start();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

     
        // TODO: Add your update logic here

        player.Update(gameTime);
        mousePositionText.Update(gameTime);
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.DarkRed);

        _spriteBatch.Begin();
        
        /*

        int index = 1;
        int columns = 2;
        
        _spriteBatch.Draw(
            _pongAtlas, 
            new Vector2(300, 300), // position
            new Rectangle((int)(index * _pongAtlas.Width / columns), 0, (int)(_pongAtlas.Width / columns), _pongAtlas.Height),
            Color.White,
            MathHelper.ToRadians(0),
            new Vector2(_pongAtlas.Width * 0.5f, _pongAtlas.Height * 0.5f),
            new Vector2(1.0f, 1.0f),
            SpriteEffects.None,
            0.0f
        );
        
        */
        player.Draw(_spriteBatch);
        mousePositionText.Draw(_spriteBatch);
        
       /* _spriteBatch.Draw(
            _logo, 
            _screenCenter, // position
            null,
            Color.White,
            MathHelper.ToRadians(
                (float)gameTime.TotalGameTime.TotalSeconds * speed),
            new Vector2(_logo.Width * 0.5f, _logo.Height * 0.5f),
            new Vector2(0.5f, 0.5f),
            SpriteEffects.None,
            0.0f
            );*/
        
        _spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}