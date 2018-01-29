using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Web.Script;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace Termin_Client.Data
{
    class Database
    {
        //Oracle wird durch Webservice ersetzt
        //externe ip 212.152.179.117
        string cs = "Provider=OraOLEDB.Oracle;Data Source=212.152.179.117/ora11g;User Id=d5b07; Password=d5b;"; //212.152.179.117 - intern 192.168.128.152
        OleDbCommand cmd = null;
        //Oracle

        public ObservableCollection<Termine> _TerminList = new ObservableCollection<Termine>();
        public ObservableCollection<Termine> TerminList { get { return _TerminList; } }

        public ObservableCollection<Car> _CarList = new ObservableCollection<Car>();
        public ObservableCollection<Car> CarList { get { return _CarList; } }

        public ObservableCollection<Worker> _WorkerList = new ObservableCollection<Worker>();
        public ObservableCollection<Worker> WorkerList { get { return _WorkerList; } }

        public ObservableCollection<Worker> _GroupList = new ObservableCollection<Worker>();
        public ObservableCollection<Worker> GroupList { get { return _GroupList; } }

        private string urlWebService = "http://10.0.0.35:8080/Terminverwaltung_Server/webresources/";     //schule: 192.168.195.61  daheim: 10.0.0.19
        private static readonly HttpClient client = new HttpClient();
        // GETs results of the webservice

        private string GETFromWebserver(string myPath)
        {
            string responseText;
            var encoding = ASCIIEncoding.ASCII;
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri(urlWebService + myPath));       //Create a HttpWebRequest object  
                httpWebRequest.Method = "GET";      //Set the Method  
                //httpWebRequest.KeepAlive = true;        //Set Keep Alive
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();        //Get the Response 
                // reads every byte of the response message
                using (var reader = new System.IO.StreamReader(httpWebResponse.GetResponseStream(), encoding))
                {
                    responseText = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GETWebService: " + ex.Message);
            }
            return responseText;
        }


        internal void getAllWorkers()
        {
            string json = GETFromWebserver("BenutzerList");
            var data = Worker.FromJson(json);
            foreach (Worker w in data)
                _WorkerList.Add(w);
            //return _WorkerList;
        }

        internal void getAllCars()
        {
            string json = GETFromWebserver("FahrzeugeList");
            var data = Car.FromJson(json);
            foreach (Car c in data)
                _CarList.Add(c);
            //return _WorkerList;
        }

        internal void getAllTermine()
        {
            string json = GETFromWebserver("TerminList");
            var data = Termine.FromJson(json);
            foreach (Termine t in data)
                _TerminList.Add(t);
            //return _WorkerList;
        }

        internal void addMemberToGroup(Worker w)
        {
            _GroupList.Add(w);
        }
    

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
