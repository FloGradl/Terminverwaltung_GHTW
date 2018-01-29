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
    /// Interaktionslogik für Startseite.xaml
    /// </summary>
    public partial class Startseite : Window
    {
        Database db = Database.newInstance();
        public Startseite()
        {
            InitializeComponent();
            Karte.Navigate("https://www.google.at/maps/@47.4353345,13.6432712,8z/data=!4m2!11m1!3e4c");
            lblWillkommen.Content += db.getUsername();
            lblTermin.Content = db.getCurrentAppointment();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            GUI.MeineTermine openTermin = new GUI.MeineTermine();
            openTermin.Show();
        }

        private void mnItmTermin(object sender, RoutedEventArgs e)
        {
            GUI.MeineTermine mt = new MeineTermine();
            mt.Show();
        }

        private void mnItmLogout(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mnItmCars(object sender, RoutedEventArgs e)
        {
            GUI.Cars guic = new Cars();
            guic.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            GUI.ProfileUser pu = new ProfileUser();
            pu.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e) //Gruppen MenuItem
        {
            GUI.GroupGUI gg = new GroupGUI();
            gg.Show();
        }
    }
}
