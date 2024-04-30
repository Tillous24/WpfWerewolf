using System;
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

namespace WpfWerewolf.Presentation_Layer.Presenters.NightActions
{
    /// <summary>
    /// Interaktionslogik für WitchAction.xaml
    /// </summary>
    public partial class WitchAction : Window
    {
        public static WitchAction _instance;
        private GameSession _gameSession;
        public WitchAction()
        {
            InitializeComponent();
            _gameSession = GameController.Instance.CurrentGameSession;
            GameController.Instance.CurrentWindow = this;


            

            
        }

        public static WitchAction Instance
        {
            get
            {
                // Create a new instance if it doesn't exist
                if (_instance == null)
                {
                    _instance = new WitchAction();
                   
                }
                _instance.InitializeComponent();
                return _instance;
            }
        }

        void Btn_Click(object sender, RoutedEventArgs e)
        {
            // Handle click event
            Button clickedBtn = (Button)sender;
            Player selectedPlayer = (Player)clickedBtn.Tag;

            MessageBox.Show($"You chose {selectedPlayer.name}.", "Decision Made", MessageBoxButton.OK, MessageBoxImage.Information);
            selectedPlayer.isAlive = false;
            GameController.Instance.HandleGameFlow();
            GameController.Instance.ShowNextWindow();
        }

        private void KillButton_Click(object sender, RoutedEventArgs e)
        {

            foreach (var player in _gameSession.ActiveParticipants())
            {
                HealWrapPanel.IsEnabled = false;
                if (player.isAlive)
                {
                    Button btn = new Button()
                    {
                        Content = $"Kill {player.name}",
                        Margin = new Thickness(5),
                        Tag = player
                    };

                    btn.Click += Btn_Click;
                    KillWrapPanel.Children.Insert(KillWrapPanel.Children.Count % 4, btn);
                }

            }

        }

        private void HealButton_Click(object sender, RoutedEventArgs e)
        {
            KillWrapPanel.IsEnabled = false;
            foreach (var player in _gameSession.ActiveParticipants())
            {
                if (!player.isAlive)
                {
                    Button btn = new Button()
                    {
                        Content = $"Heal {player.name}",
                        Margin = new Thickness(5),
                        Tag = player
                    };

                    btn.Click += Btn_Click;
                    HealWrapPanel.Children.Insert(KillWrapPanel.Children.Count % 4, btn);
                }

            }

        }
    }
}
