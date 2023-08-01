using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkGame.Library
{
    public struct InputState
    {
        private float[] signals;
        public readonly int SignalCount;

        public InputState()
        {
            SignalCount = Enum.GetValues(typeof(InputSignal)).Length;
            signals = new float[SignalCount];
        }

        public InputState(float[] signals)
        {
            SignalCount = Enum.GetValues(typeof(InputSignal)).Length;
            if (signals.Length != SignalCount)
            {
                throw new Exception("Expecting array of size " + SignalCount + " and got " + signals.Length + ".");
            }
            this.signals = signals;
        }

        public float GetInput(InputSignal signal)
        {
            return signals[(int)signal];
        }

        public void Read(NetIncomingMessage message)
        {
            for (int i = 0; i < SignalCount; i++)
            {
                signals[i] = message.ReadFloat();
            }
        }

        public void Write(NetOutgoingMessage message)
        {
            for (int i = 0; i < SignalCount; i++)
            {
                message.Write(signals[i]);
            }
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is InputState))
            {
                return false;
            }

            var other = (InputState)obj;
            for (int i = 0; i < SignalCount; i++)
            {
                if (other.signals[i] != signals[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
