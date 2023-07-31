using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NetworkGame.Library;
using NetworkGame.Managers;
using System;
using System.ComponentModel;

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

    float[] lastInputs;

    public float playerSpeed = 2;

    public Game1() : base()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        networkManager = new NetworkManager();
        
        inputManager = new InputManager(InputMode.mouseAndKeyboard);
        inputManager.SetBinding(InputSignal.HorizontalMovement, new KeyInput(Keys.A, Keys.D));
        inputManager.SetBinding(InputSignal.VerticalMovement, new KeyInput(Keys.W, Keys.S));
        lastInputs = new float[4] { 0, 0, 0, 0, };

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
        var signals = inputManager.Signals;
        //if (CheckInputsChanged())
        {
            networkManager.SendInputs(signals);
        }
        Array.Copy(signals, lastInputs, signals.Length);

        base.Update(gameTime);
    }

    private bool CheckInputsChanged()
    {
        if (lastInputs == null)
        {
            return true;
        }

        for (int i = 0; i < lastInputs.Length; i++)
        {
            if (lastInputs[i] != inputManager.Signals[i])
            {
                return true;
            }
        }

        return false;
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
            networkManager.Disconnect("User disconnected.");
        }
    }
}