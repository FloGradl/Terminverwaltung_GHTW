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
    /// Interaktionslogik für Cars.xaml
    /// </summary>
    public partial class Cars : Window
    {
        Database db = Database.newInstance();
        public Cars()
        {
            InitializeComponent();
            db.getAllCars();
            db.getAllTermine();
            DataContext = db;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e) //wenn Termin geklickt wird, werden frei autos in der unteren Liste angezeigt
        {

        }
    }
}
