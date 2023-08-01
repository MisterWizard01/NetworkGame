using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NetworkGame.Library;
using NetworkGame.Managers;
using System;

namespace NetworkGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch spriteBatch;
    private NetworkManager networkManager;
    private InputManager inputManager;
    private PlayerManager playerManager;
    private Texture2D playerTexture;
    private SpriteFont font;

    InputState previousInputState;

    public Game1() : base()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Window.Title = "Network Game";
        _graphics.IsFullScreen = false;
        _graphics.PreferredBackBufferWidth = 640;
        _graphics.PreferredBackBufferHeight = 480;
        _graphics.ApplyChanges();

        networkManager = new NetworkManager();
        
        inputManager = new InputManager(InputMode.mouseAndKeyboard);
        inputManager.SetBinding(InputSignal.HorizontalMovement, new KeyInput(Keys.A, Keys.D));
        inputManager.SetBinding(InputSignal.VerticalMovement, new KeyInput(Keys.W, Keys.S));
        previousInputState = new InputState();

        playerManager = new PlayerManager(networkManager);
    }

    protected override void Initialize()
    {
        networkManager.Start();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        playerTexture = new Texture2D(GraphicsDevice, 1, 1);
        playerTexture.SetData(new Color[] { Color.White });
        font = Content.Load<SpriteFont>("font");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        networkManager.Update();
        inputManager.Update(gameTime.ElapsedGameTime.Milliseconds);
        var inputState = inputManager.InputState;
        if (!previousInputState.Equals(inputState))
        {
            networkManager.SendInputs(inputState);
        }
        previousInputState = inputState;

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(networkManager.Active ? Color.Green : Color.Red);

        spriteBatch.Begin();

        if (networkManager.Active)
        {
            playerManager.Draw(spriteBatch, playerTexture, font);
        }

        spriteBatch.End();

        base.Draw(gameTime);
    }

    protected override void OnExiting(object sender, EventArgs args)
    {
        base.OnExiting(sender, args);

        if (networkManager.Active)
        {
            networkManager.Disconnect("User closed the application.");
        }
    }
}