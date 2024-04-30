using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Werewolf_Companion.Domain_Model;

namespace WpfWerewolf.Domain_Model.Managers
{
    public class SessionManager
    {
        private GameSession _gameSession;
        private PlayerManager _playerManager;

        
        public SessionManager(GameSession _gameSession)
        {
            this._gameSession = _gameSession;

        }

        public void AssignGameRoles()
        {
            Shuffle(_gameSession.SelectedRoles());
            Shuffle(_gameSession.ActiveParticipants());

            // Iterate over the shuffled lists to assign roles to players
            int playerIndex = 0;
            foreach (Role role in _gameSession.SelectedRoles())
            {
                // Get the next player
                Player player = _gameSession.ActiveParticipants()[playerIndex];

                // Assign the role to the player
                player.assignedRole = role;

                // Move to the next player
                playerIndex++;

                // If we've reached the end of the player list, reset the index
                if (playerIndex >= _gameSession.ActiveParticipants().Count)
                {
                    playerIndex = 0;
                }
            }
        }

        private void Shuffle<T>(IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }


    }
}
