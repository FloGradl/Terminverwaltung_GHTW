using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
using Termin_Client.GUI;

namespace Termin_Client
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string cs = "Provider=OraOLEDB.Oracle;Data Source=192.168.128.152/ora11g;User Id=d5b07; Password=d5b;"; //212.152.179.117 - intern 192.168.128.152
        OleDbCommand cmd = null;
        public MainWindow()
        {
            InitializeComponent();
            connect();
        }

        public void connect()
        {
            using (OleDbConnection conn = new OleDbConnection(cs))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btn_Login(object sender, RoutedEventArgs e)
        {
            Boolean found = false;
            string benutzerName = null;
            string passwort = null;
            string checkLogin = "select bname, passwort from benutzer";
            using (OleDbConnection conn = new OleDbConnection(cs))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                cmd = new OleDbCommand(checkLogin, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        benutzerName = reader[0].ToString();
                        passwort = reader[1].ToString();
                        if (benutzerName == txtUser.Text)
                        {
                            if (passwort == pwPasswort.Password.ToString())
                            {
                                Startseite sp = new Startseite();
                                sp.Show();
                                this.Close();
                                found = true;
                            }
                        }
                    }
                    if (found == false)
                    {
                        MessageBox.Show("Logindaten falsch!");
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
        }
    }
}
