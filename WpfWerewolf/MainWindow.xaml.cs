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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfWerewolf.Presentation_Layer.Presenters;

namespace WpfWerewolf
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    { 
        public MainWindow()
        {
            InitializeComponent();
        }
        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            Hide(); // hide the start menu window
            var newSession = new NewSession(); // create a new game window
            newSession.ShowDialog(); // show the new game window as modal dialog
            Show(); // show the start menu window again
            

        }
    }
}
