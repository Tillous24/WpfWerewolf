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
using WpfWerewolf.Presentation_Layer.Helpers;

namespace WpfWerewolf.Presentation_Layer.Presenters.NightActions
{
    /// <summary>
    /// Interaktionslogik für KnightAction.xaml
    /// </summary>
    public partial class KnightAction : Window
    {
        private static KnightAction _instance;
        private GameSession _gameSession;
        public KnightAction()
        {
            InitializeComponent();
            _gameSession = GameController.Instance.CurrentGameSession;
            GameController.Instance.CurrentWindow = this;


            foreach (var player in _gameSession.ActiveParticipants())
            {
                Button btn = new Button()
                {
                    Content = $"Protect {player.name}",
                    Margin = new Thickness(5),
                    Tag = player
                };

                btn.Click += Btn_Click;
                buttonsWrapPanel.Children.Insert(buttonsWrapPanel.Children.Count % 4, btn);
            }

            void Btn_Click(object sender, RoutedEventArgs e)
            {
                // Handle click event
                Button clickedBtn = (Button)sender;
                Player selectedPlayer = (Player)clickedBtn.Tag;

                // Proceed with protecting the player
                MessageBox.Show($"You chose to protect {selectedPlayer.name}.", "Decision Made", MessageBoxButton.OK, MessageBoxImage.Information);
                selectedPlayer.isProtected = true;
                GameController.Instance.HandleGameFlow();
                GameController.Instance.ShowNextWindow();
            }
        }
        public static KnightAction Instance
        {
            get
            {
                // Create a new instance if it doesn't exist
                if (_instance == null)
                {
                    _instance = new KnightAction();

                }
                _instance.InitializeComponent();
                return _instance;
            }

        }

    }
}
