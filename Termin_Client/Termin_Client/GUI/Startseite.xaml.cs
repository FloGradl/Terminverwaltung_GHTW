﻿using System;
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

namespace Termin_Client.GUI
{
    /// <summary>
    /// Interaktionslogik für Startseite.xaml
    /// </summary>
    public partial class Startseite : Window
    {
        public Startseite()
        {
            InitializeComponent();
            Karte.Navigate("https://www.google.at/maps/@47.4353345,13.6432712,8z/data=!4m2!11m1!3e4c");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            GUI.MeineTermine openTermin = new GUI.MeineTermine();
            openTermin.Show();
        }
    }
}
