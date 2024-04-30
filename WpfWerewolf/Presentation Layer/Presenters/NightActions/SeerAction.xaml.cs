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
    /// Interaktionslogik für SeerAction.xaml
    /// </summary>
    public partial class SeerAction : Window
    {
        private static SeerAction _instance;
        private GameSession _gameSession;
        public SeerAction()
        {
            InitializeComponent();
            _gameSession = GameController.Instance.CurrentGameSession;
            GameController.Instance.CurrentWindow = this;


            foreach (var player in _gameSession.ActiveParticipants())
            {
                if (player.isAlive)
                {
                    Button btn = new Button()
                    {
                        Content = $"See {player.name}",
                        Margin = new Thickness(5),
                        Tag = player
                    };

                    btn.Click += Btn_Click;
                    buttonsWrapPanel.Children.Insert(buttonsWrapPanel.Children.Count % 4, btn);
                }

            }

            void Btn_Click(object sender, RoutedEventArgs e)
            {
                // Handle click event
                Button clickedBtn = (Button)sender;
                Player selectedPlayer = (Player)clickedBtn.Tag;

                // Proceed with protecting the player
                MessageBox.Show($"{selectedPlayer.name} is {selectedPlayer.assignedRole}", "Decision Made", MessageBoxButton.OK, MessageBoxImage.Information);
                selectedPlayer.isAlive = false;
                GameController.Instance.HandleGameFlow();
                GameController.Instance.ShowNextWindow();
            }
        }

        public static SeerAction Instance
        {
            get
            {
                // Create a new instance if it doesn't exist
                if (_instance == null)
                {
                    _instance = new SeerAction();

                }
                _instance.InitializeComponent();
                return _instance;
            }
        }
    }
}
