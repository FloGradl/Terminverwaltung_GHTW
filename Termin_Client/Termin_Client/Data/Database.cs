using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin_Client.Data
{
    class Database
    {
        public ObservableCollection<Termine> _TerminList = new ObservableCollection<Termine>();
        public ObservableCollection<Termine> TerminList { get { return _TerminList; } }

        private static Database instance = null;

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
    }
}
