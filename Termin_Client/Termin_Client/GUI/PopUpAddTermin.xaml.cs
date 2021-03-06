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
using Termin_Client.Data;

namespace Termin_Client.GUI
{
    /// <summary>
    /// Interaktionslogik für PopUpAddTermin.xaml
    /// </summary>
    public partial class PopUpAddTermin : Window
    {
        public PopUpAddTermin()
        {
            InitializeComponent();
        }

        private void btnAddTermin(object sender, RoutedEventArgs e)
        {
            Database db = Database.newInstance();
            DateTime? date = datepickerP.SelectedDate;
            db.addTermin(new Termine(Convert.ToDateTime(date.Value.ToShortDateString()), txtboxOrt.Text, txtboxInfo.Text, "--"));
        }
    }
}
