using Microsoft.Win32;
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

namespace Termin_Client.GUI
{
    /// <summary>
    /// Interaktionslogik für ProfileUser.xaml
    /// </summary>
    public partial class ProfileUser : Window
    {
        public ProfileUser()
        {
            InitializeComponent();
            imgUser.Source = new BitmapImage(new Uri(@"pack://application:,,,/Images/defaultUser.png"));
        }

        private void UploadPic_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgUser.Source = new BitmapImage(new Uri(op.FileName));
            }
        }
    }
}
