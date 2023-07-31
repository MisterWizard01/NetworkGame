using Lidgren.Network;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkGame.Library
{
    public class Player
    {
        private string name;
        private Vector2 position;

        public string Name { get => name; set => name = value; }
        public Vector2 Position { get => position; set => position = value; }
        public float X
        {
            get { return Position.X; }
            set { position = new Vector2(value, Y); }
        }
        public float Y
        {
            get { return Position.Y; }
            set { position = new Vector2(X, value); }
        }

        public Player()
        {
            name = string.Empty;
            position = Vector2.Zero;
        }

        public Player(string username, float x, float y)
        {
            name = username;
            X = x;
            Y = y;
        }
    }
}
