using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Werewolf_Companion.Domain_Model;

namespace WpfWerewolf.Domain_Model.Managers
{
    public class PlayerManager
    {
        private List<Player> players;

        public PlayerManager()
        {
            players = new List<Player>();
        }

        // Add a player to the manager
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        // Remove a player from the manager
        public void RemovePlayer(Player player)
        {
            players.Remove(player);
        }

        // Set the IsAlive state of a player
        public void SetIsAlive(Player player, bool isAlive)
        {
            player.isAlive = isAlive;
        }

        // Set the IsProtected state of a player
        public void SetIsProtected(Player player, bool isProtected)
        {
            player.isProtected = isProtected;
        }

        // Set the IsCharmed state of a player
        public void SetIsCharmed(Player player, bool isCharmed)
        {
            player.isCharmed = isCharmed;
        }

        // Get the assigned role of a player
        public Role GetAssignedRole(Player player)
        {
            return player.assignedRole;
        }

        // Set the assigned role of a player
        public void SetAssignedRole(Player player, Role role)
        {
            player.assignedRole = role;
        }

        // Get the name of a player
        public string GetName(Player player)
        {
            return player.name;
        }

        // Set the name of a player
        public void SetName(Player player, string name)
        {
            player.name = name.ToLower();
        }
    }
}
