using Microsoft.Xna.Framework.Input;
using NetworkGame.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkGame.Managers
{
    //InputManager polls the keyboard, mouse, and gamepad each frame, then reports a list of signals (floats) representing active inputs.

    class InputManager
    {
        public Dictionary<InputMode, Input[]> Bindings;
        public InputState InputState { get; set; }
        public InputMode Mode { get; set; }

        public InputManager(InputMode mode)
        {
            Mode = mode;
            InputState = new InputState();
            Bindings = new Dictionary<InputMode, Input[]>()
            {
                { InputMode.mouseAndKeyboard, new Input[InputState.SignalCount] },
                { InputMode.keyboardOnly, new Input[InputState.SignalCount] },
                { InputMode.XBoxController, new Input[InputState.SignalCount] },
            };
        }

        public void Update(double gameTime)
        {
            float[] signals = new float[InputState.SignalCount];
            for (int i = 0; i < signals.Length; i++)
            {
                signals[i] = Bindings[Mode][i]?.GetSignalValue(Mouse.GetState(), Keyboard.GetState(), GamePad.GetState(1)) ?? 0;
            }

            InputState = new InputState(signals);
        }

        public void SetBinding(InputSignal signalName, Input input)
        {
            SetBinding(Mode, signalName, input);
        }

        public void SetBinding(InputMode mode, InputSignal signalName, Input input)
        {
            Bindings[mode][(int)signalName] = input;
        }
    }
}
