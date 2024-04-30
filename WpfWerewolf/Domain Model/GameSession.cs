using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf_Companion.Domain_Model
{
    public class GameSession
    {
        // Private members
        private Random _randomGenerator;
        private List<Role> _selectedRoles;
        private List<Player> _activeParticipants;


        // Initialize the game session with a given list of selected roles
        public GameSession()
        {
            // Create a copy of the provided selected roles list
            _selectedRoles = new List<Role>();

            // Initialize empty collections for active participants and current turn order
            _activeParticipants = new List<Player>();

            // Initialize the random number generator
            _randomGenerator = new Random();
        }

        public List<Player> ActiveParticipants() {  return _activeParticipants; }
        public void AddPlayer(Player player)
        {
            _activeParticipants.Add(player);
        }        
        public void RemovePlayer(Player player)
        {
            _activeParticipants.Remove(player);
        }

        //get the number of elements in list
        public int NumParticipants() { return _activeParticipants.Count;}

        public List<Role> SelectedRoles() { return _selectedRoles; }
        public void AddRole(Role role)
        {
            _selectedRoles.Add(role);
        }        
        public void RemoveRole(Role role)
        {
            _selectedRoles.Remove(role);
        }

        public void ClearRoles()
        { 
            _selectedRoles.Clear(); 
        }

        public int NumRoles() {  return _activeParticipants.Count;}

    }
}
