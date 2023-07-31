using Microsoft.Xna.Framework;
using NetworkGame.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkGame.Managers
{
    class CollisionManager
    {
        public static bool CheckCollision(Rectangle rect, string username, List<Player> players)
        {
            foreach (var player in players)
            {
                if (player.Name != username)
                {
                    var playerRec = new Rectangle((int)player.X, (int)player.Y, 32, 32);
                    if (playerRec.Intersects(rect))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
