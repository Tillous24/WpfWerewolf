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
    
    public partial class Voting : Window
    {
        private static Voting _instance; 
        public Voting()
        {
            InitializeComponent();
        }

        public static Voting Instance
        {
            get
            {
                // Create a new instance if it doesn't exist
                if (_instance == null)
                {
                    _instance = new Voting();
                    _instance.InitializeComponent();
                }
                return _instance;
            }
        }
    }
}
