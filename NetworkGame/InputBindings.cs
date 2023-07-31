using Microsoft.Xna.Framework.Input;
using NetworkGame.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkGame;

public class Binding
{
    public InputSignal SignalName { get; set; }
    public Dictionary<InputMode, Input> Inputs { get; set; }

    public Binding(InputSignal signalName, InputMode mode, Input input)
    {
        SignalName = signalName;
        Inputs = new Dictionary<InputMode, Input>
        {
            { mode, input }
        };
    }
}

public interface Input
{
    public float GetSignalValue(MouseState mouseState, KeyboardState keyboardState, GamePadState gamePadState, float reference = 0);
}

public class KeyInput : Input
{
    public Keys negativeKey, positiveKey;

    public KeyInput(Keys negativeKey, Keys positiveKey)
    {
        this.negativeKey = negativeKey;
        this.positiveKey = positiveKey;
    }

    public float GetSignalValue(MouseState mouseState, KeyboardState keyboardState, GamePadState gamePadState, float reference = 0)
    {
        return (keyboardState.IsKeyDown(positiveKey) ? 1 : 0) - (keyboardState.IsKeyDown(negativeKey) ? 1 : 0);
    }
}

public class MouseButtonInput : Input
{
    public MouseButtons negativeButton, positiveButton;

    public float GetSignalValue(MouseState mouseState, KeyboardState keyboardState, GamePadState gamePadState, float reference = 0)
    {
        return ButtonToFloat(mouseState, positiveButton) - ButtonToFloat(mouseState, negativeButton);
    }

    public static float ButtonToFloat(MouseState mouseState, MouseButtons mouseControl)
    {
        switch (mouseControl)
        {
            case MouseButtons.LeftButton:
                return mouseState.LeftButton == ButtonState.Pressed ? 1 : 0;

            case MouseButtons.MiddleButton:
                return mouseState.MiddleButton == ButtonState.Pressed ? 1 : 0;

            case MouseButtons.RightButton:
                return mouseState.RightButton == ButtonState.Pressed ? 1 : 0;

            case MouseButtons.XButton1:
                return mouseState.XButton1 == ButtonState.Pressed ? 1 : 0;

            case MouseButtons.XButton2:
                return mouseState.XButton2 == ButtonState.Pressed ? 1 : 0;

            default:
                return 0;
        }
    }
}

public class MouseAxisInput : Input
{
    public MouseAxes mouseAxis;

    public float GetSignalValue(MouseState mouseState, KeyboardState keyboardState, GamePadState gamePadState, float reference = 0)
    {
        switch (mouseAxis)
        {
            case MouseAxes.MouseX:
                return mouseState.X - reference;

            case MouseAxes.MouseY:
                return mouseState.Y - reference;

            case MouseAxes.VerticalScroll:
                return mouseState.ScrollWheelValue - reference;

            case MouseAxes.HorizontalScroll:
                return mouseState.HorizontalScrollWheelValue - reference;

            default:
                return 0;
        }
    }
}

public class GamePadButtonInput : Input
{
    public Buttons negativeButton, positiveButton;

    public float GetSignalValue(MouseState mouseState, KeyboardState keyboardState, GamePadState gamePadState, float reference = 0)
    {
        return (gamePadState.IsButtonDown(positiveButton) ? 1 : 0) - (gamePadState.IsButtonDown(negativeButton) ? 1 : 0);
    }
}

public class GamePadAxisInput : Input
{
    public Buttons gamePadAxis;

    public float GetSignalValue(MouseState mouseState, KeyboardState keyboardState, GamePadState gamePadState, float reference = 0)
    {
        throw new NotImplementedException();
    }
}