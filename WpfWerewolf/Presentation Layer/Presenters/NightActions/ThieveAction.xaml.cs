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

namespace WpfWerewolf.Presentation_Layer.Presenters.NightActions
{
    /// <summary>
    /// Interaktionslogik für ThieveAction.xaml
    /// </summary>
    public partial class ThieveAction : Window
    {
        private static ThieveAction _instance;
        public ThieveAction()
        {
            InitializeComponent();
        }

        public static ThieveAction Instance
        {
            get
            {
                // Create a new instance if it doesn't exist
                if (_instance == null)
                {
                    _instance = new ThieveAction();
                    
                }
                _instance.InitializeComponent();
                return _instance;
            }
        }
    }
}
