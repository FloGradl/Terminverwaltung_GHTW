using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaktionslogik für GroupGUI.xaml
    /// </summary>
    public partial class GroupGUI : Window
    {
        ObservableCollection<Worker> workerList = new ObservableCollection<Worker>();
        ObservableCollection<Worker> groupListList = new ObservableCollection<Worker>();
        Database db = Database.newInstance();
        public GroupGUI()
        {
            InitializeComponent();
            workerList = db.getAllWorkers();
            DataContext = db;
        }
    }
}
