using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            String line = "";
            using (StreamReader sr = new StreamReader(mydocpath + @"\ImagePath.txt"))
            {
                line = sr.ReadToEnd();
                line = line.Replace("\\", "/");
                line = line.Replace("\r\n", "");
            }
            if(line == "")
                imgUser.Source = new BitmapImage(new Uri(@"pack://application:,,,/Images/defaultUser.png"));
            else
                imgUser.Source = new BitmapImage(new Uri(line, UriKind.Absolute));
        }

        private void UploadPic_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "";
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgUser.Source = new BitmapImage(new Uri(op.FileName));
                filePath = op.FileName;
            }
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(mydocpath + @"\ImagePath.txt"))
            {
                    outputFile.WriteLine(filePath);
            }
        }

        private void SaveUserSettings(object sender, RoutedEventArgs e)
        {

        }

        private void ChangePassword(object sender, RoutedEventArgs e)
        {

        }
    }
}
