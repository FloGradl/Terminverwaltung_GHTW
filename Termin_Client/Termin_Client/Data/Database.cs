using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin_Client.Data
{
    class Database
    {
        //Oracle wird durch Webservice ersetzt
        string cs = "Provider=OraOLEDB.Oracle;Data Source=192.168.128.152/ora11g;User Id=d5b07; Password=d5b;"; //212.152.179.117 - intern 192.168.128.152
        OleDbCommand cmd = null;
        //Oracle

        public ObservableCollection<Termine> _TerminList = new ObservableCollection<Termine>();
        public ObservableCollection<Termine> TerminList { get { return _TerminList; } }

        public ObservableCollection<Car> _CarList = new ObservableCollection<Car>();
        public ObservableCollection<Car> CarList { get { return _CarList; } }

        public List<Car> freeCarsList;

        private static Database instance = null;
        private String username;

        public static Database newInstance()
        {
            if (instance == null)
            {
                instance = new Database();
            }
            return instance;
        }

        public void addTermin(Termine t)
        {
            _TerminList.Add(t);
        }

        public void addCar(Car c)
        {
            _CarList.Add(c);
        }

        public void setUsername(String user)
        {
            this.username = user;
        }

        public String getUsername()
        {
            return username;
        }

        public String getCurrentAppointment()
        {
            return "not developed yet";
        }
        
        public List<Car> getFreeCars()
        {
            return freeCarsList;
        }

        public ObservableCollection<Car> loadCars()
        {
            string command = "Select nummerntafel, bezeichnung From Fahrzeuge;";
            using (OleDbConnection conn = new OleDbConnection(cs))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                cmd = new OleDbCommand(command, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Car c = new Car(reader[0].ToString(), reader[1].ToString());
                        if (!_CarList.Contains(c))
                            _CarList.Add(c);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                reader.Close();
            }

                        return _CarList;
        }
    }
}
