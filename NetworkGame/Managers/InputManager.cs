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
        public float[] Signals { get; set; }
        public InputMode Mode { get; set; }

        public readonly int NumberOfSignals;

        public InputManager(InputMode mode)
        {
            NumberOfSignals = Enum.GetNames(typeof(InputSignal)).Length;
            Bindings = new Dictionary<InputMode, Input[]>()
            {
                { InputMode.mouseAndKeyboard, new Input[NumberOfSignals] },
                { InputMode.keyboardOnly, new Input[NumberOfSignals] },
                { InputMode.XBoxController, new Input[NumberOfSignals] },
            };
            Signals = new float[NumberOfSignals];
            Mode = mode;
        }

        public void Update(double gameTime)
        {
            for (int i = 0; i < NumberOfSignals; i++)
            {
                Signals[i] = Bindings[Mode][i]?.GetSignalValue(Mouse.GetState(), Keyboard.GetState(), GamePad.GetState(1)) ?? 0;
            }
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
