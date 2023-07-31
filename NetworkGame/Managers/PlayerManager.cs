using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NetworkGame.Library;
using NetworkGame.MyEventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkGame.Managers;

public class PlayerManager
{
    private List<Player> players;
    private NetworkManager networkManager;

    public PlayerManager(NetworkManager networkManager)
    {
        players = new List<Player>();
        this.networkManager = networkManager;
        networkManager.PlayerUpdateEvent += PlayerUpdate;
        networkManager.KickPlayerEvent += KickPlayer;
    }

    private void PlayerUpdate(object sender, PlayerUpdateEventArgs e)
    {
        foreach (var player in e.Players)
        {
            var thisPlayer = players.FirstOrDefault(p => p.Name == player.Name);
            if (thisPlayer != null)
            {
                thisPlayer.Position = player.Position;
            }
            else
            {
                AddPlayer(player);
            }
        }
    }
    
    private void KickPlayer(object sender, KickPlayerEventArgs e)
    {
        var thisPlayer = players.FirstOrDefault(p => p.Name == e.Username);
        if (thisPlayer != null)
        {
            RemovePlayer(thisPlayer);
        }
    }

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void RemovePlayer(Player player)
    { 
        players.Remove(player);
    }

    public void Draw(SpriteBatch spriteBatch, Texture2D playerTexture, SpriteFont font)
    {
        foreach (var player in players)
        {
            spriteBatch.Draw(playerTexture, new Rectangle(player.Position.ToPoint(), new Point(32,32)), Color.Lavender);
            spriteBatch.DrawString(font, player.Name, player.Position - new Vector2(0, 15), Color.Black);
        }
    }
}
