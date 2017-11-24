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
using Termin_Client.Data;

namespace Termin_Client.GUI
{
    /// <summary>
    /// Interaktionslogik für MeineTermine.xaml
    /// </summary>
    public partial class MeineTermine : Window
    {
        Database db = Database.newInstance();
        public MeineTermine()
        {
            InitializeComponent();
            DataContext = db;
        }

        private void btnAddTermin(object sender, RoutedEventArgs e)
        {
            GUI.PopUpAddTermin addTermin = new GUI.PopUpAddTermin();
            addTermin.Show();
        }
    }
}
