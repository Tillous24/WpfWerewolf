using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Werewolf_Companion.Domain_Model;
using WpfWerewolf.Domain_Model.Managers;

namespace WpfWerewolf.Presentation_Layer.Presenters
{
    /// <summary>
    /// Interaktionslogik für NewSession.xaml
    /// </summary>
    public partial class NewSession : Window
    {
        GameSession _gameSession;
        SessionManager _sessionManager;
        
        public NewSession()
        {
            InitializeComponent();
            _gameSession = new GameSession();
            _sessionManager = new SessionManager(_gameSession);
            GameController.Instance.CurrentGameSession = _gameSession;
            GameController.Instance.CurrentSessionManager = _sessionManager;
            toggleCupid.IsEnabled = false;
            toggleHunter.IsEnabled = false;
            toggleThieve.IsEnabled = false;

        }

        private void BtnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            string playerName = txtName.Text.Trim();

            if (!string.IsNullOrEmpty(playerName))
            {
                // Create a new Player object with the entered name
                Player newPlayer = new Player(playerName);

                // Add the new player to the game session's list of active participants
                _gameSession.AddPlayer(newPlayer);

                // Clear the text box after adding the player
                txtName.Text = string.Empty;

                txtNumberOfPlayers.Text = _gameSession.ActiveParticipants().Count.ToString();
            }
            else
            {
                MessageBox.Show("Please enter a player name.");
            }
        }

        private void BtnOkay_Click(object sender, RoutedEventArgs e)
        {
            
            
            // Check if any roles are selected
            bool isRoleSelected = false;

            if (toggleCupid.IsChecked == true)
            {
                
                _gameSession.AddRole(new Cupid());
                isRoleSelected = true;
            }

            if (toggleWitch.IsChecked == true)
            {
                _gameSession.AddRole(new Witch());
                isRoleSelected = true;
            }

            if (toggleGirl.IsChecked == true)
            {
                _gameSession.AddRole(new LittleGirl());
                isRoleSelected = true;
            }

            if (toggleHunter.IsChecked == true)
            {
                _gameSession.AddRole(new Hunter());
                isRoleSelected = true;
            }

            if (toggleKnight.IsChecked == true)
            {
                _gameSession.AddRole(new Knight());
                isRoleSelected = true;
            }

            if (togglePipper.IsChecked == true)
            {
                _gameSession.AddRole(new Piper());
                isRoleSelected = true;
            }

            if (toggleSeer.IsChecked == true)
            {
                _gameSession.AddRole(new Seer());
                isRoleSelected = true;
            }

            if (toggleThieve.IsChecked == true) 
            { 
                _gameSession.AddRole(new Thieve());
                isRoleSelected = true;
            }

            // Add 2 werewolves by default
            _gameSession.AddRole(new Werewolf());
            _gameSession.AddRole(new Werewolf());

            // If the number of players is greater than the number of roles selected, add villagers
            int numRoles = _gameSession.NumRoles();
            int numPlayers = _gameSession.NumParticipants();

            if (numPlayers < numRoles) 
            {
                _gameSession.ClearRoles();
                ClearSelectedRoles();
                MessageBox.Show("Insufficient players for the selected roles.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            while (numPlayers > numRoles)
            {
                _gameSession.AddRole(new Villager());
                numRoles++;
            }

            _sessionManager.AssignGameRoles();
            
            Close();
            GameController.Instance.StartRound();
        }

        //Uncheck every Checkbox
        private void ClearSelectedRoles()
        {
            toggleCupid.IsChecked = false;
            togglePipper.IsChecked = false;
            toggleSeer.IsChecked = false;
            toggleThieve.IsChecked = false;
            toggleGirl.IsChecked = false;
            toggleHunter.IsChecked = false;
            toggleKnight.IsChecked = false;
            toggleWitch.IsChecked = false;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
