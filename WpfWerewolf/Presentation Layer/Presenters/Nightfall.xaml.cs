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
using WpfWerewolf.Presentation_Layer.Presenters.NightActions;

namespace WpfWerewolf.Presentation_Layer.Presenters
{
    /// <summary>
    /// Interaktionslogik für Nightfall.xaml
    /// </summary>
    public partial class Nightfall : Window
    {
        private static Nightfall _instance;
        public Nightfall()
        {
            InitializeComponent();
            GameController.Instance.CurrentWindow = this;
        }

        private void BtnBegin_Click(object sender, RoutedEventArgs e)
        {
            GameController.Instance.CurrentPhase = "NightActions";
            GameController.Instance.CurrentWindow = this;
            GameController.Instance.HandleGameFlow();
            GameController.Instance.ShowNextWindow();
        }

        public static Nightfall Instance
        {
            get
            {
                // Create a new instance if it doesn't exist
                if (_instance == null)
                {
                    _instance = new Nightfall();
                    _instance.InitializeComponent();
                }
                return _instance;
            }
        }
    }
}
