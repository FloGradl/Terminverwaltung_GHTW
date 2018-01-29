using GongSolutions.Wpf.DragDrop;
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
    public partial class GroupGUI : Window, IDropTarget
    {
        ObservableCollection<Worker> workerList = new ObservableCollection<Worker>();
        ObservableCollection<Worker> groupListList = new ObservableCollection<Worker>();
        Database db = Database.newInstance();

        void IDropTarget.DragOver(IDropInfo dropInfo)
        {
            ExampleItemViewModel sourceItem = dropInfo.Data as ExampleItemViewModel;
            ExampleItemViewModel targetItem = dropInfo.TargetItem as ExampleItemViewModel;

            if (sourceItem != null && targetItem != null && targetItem.CanAcceptChildren)
            {
                dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                dropInfo.Effects = DragDropEffects.Copy;
            }
        }

        void IDropTarget.Drop(IDropInfo dropInfo)
        {
            ExampleItemViewModel sourceItem = dropInfo.Data as ExampleItemViewModel;
            ExampleItemViewModel targetItem = dropInfo.TargetItem as ExampleItemViewModel;
            targetItem.Children.Add(sourceItem);
            sourceItem.Children.Remove(targetItem);
        }

        class ExampleItemViewModel
        {
            public bool CanAcceptChildren { get; set; }
            public ObservableCollection<ExampleItemViewModel> Children { get; private set; }
        }

        public GroupGUI()
        {
            InitializeComponent();
            //workerList = db.WorkerList;
            DataContext = db;

             
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string groupName = GroupName.Text;
            newGroup.Items.Refresh();
            for(int i = 0; i < newGroup.Items.Count; i++)
            {
                //get a faficke workershit aus dem gonzen scheiß un d gibs in a methode weiter olta recksscheiß
            }
            foreach (var item in newGroup.Items.OfType<Worker>())
            {
                db.addMemberToGroup(new Worker(item.Name, item.Email, item.Telnr));
            }
        }
    }
}

