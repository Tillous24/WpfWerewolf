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

namespace WpfWerewolf.Presentation_Layer.Presenters
{
    /// <summary>
    /// Interaktionslogik für Sunrise.xaml
    /// </summary>
    public partial class Sunrise : Window
    {
        
        public Sunrise()
        {
            InitializeComponent();
            
        }

        private void BtnEnd_Click(object sender, RoutedEventArgs e)
        {
            GameController.Instance.CurrentWindow.Close();
        }
    }
}
