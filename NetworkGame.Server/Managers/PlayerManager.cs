using Lidgren.Network;
using Microsoft.Xna.Framework;
using NetworkGame.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkGame.Server.Managers
{
    public class PlayerManager
    {
        private List<PlayerAndConnection> players;
        private Dictionary<PlayerAndConnection, InputState> playerInputStates;

        public int PlayerCount => players.Count;

        public PlayerManager()
        {
            players = new List<PlayerAndConnection>();
            playerInputStates = new Dictionary<PlayerAndConnection, InputState>();
        }

        public void Update(TimeSpan time)
        {
            for(int i = 0; i < players.Count; i++)
            {
                PlayerAndConnection player = players[i];
                InputState inputState = playerInputStates[player];

                Vector2 inputVector = new Vector2(inputState.GetInput(InputSignal.HorizontalMovement), inputState.GetInput(InputSignal.VerticalMovement));
                if (inputVector.LengthSquared() > 0)
                {
                    player.Player.Position += Vector2.Normalize(inputVector) * 120 * (float)time.TotalSeconds;
                }
            }
        }

        public void AddPlayer(PlayerAndConnection player)
        {
            players.Add(player);
            playerInputStates.Add(player, new InputState());
        }

        public void RemovePlayer(PlayerAndConnection player)
        {
            players.Remove(player);
            playerInputStates.Remove(player);
        }

        public PlayerAndConnection GetPlayer(int index)
        {
            return players[index];
        }

        public PlayerAndConnection GetPlayer(string name)
        {
            return players.FirstOrDefault(p => p.Player.Name == name);
        }

        public PlayerAndConnection GetPlayer(NetConnection connection)
        {
            return players.FirstOrDefault(p => p.Connection == connection);
        }

        public void SetInputState(PlayerAndConnection player, InputState state)
        {
            playerInputStates[player] = state;
        }

        public void WriteAllPlayers(NetOutgoingMessage message)
        {
            for(int i = 0; i < players.Count; i++)
            {
                Player player = players[i].Player;
                message.Write(player.Name);
                message.Write(player.X);
                message.Write(player.Y);
            }
        }
    }
}
