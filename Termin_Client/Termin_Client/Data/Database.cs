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
        public ObservableCollection<Termin> _TerminList = new ObservableCollection<Termin>();
        public ObservableCollection<Termin> TerminList { get { return _TerminList; } }

        private static Database instance = null;

        public static Database newInstance()
        {
            if(instance == null)
            {
                instance = new Database();
            }
            return instance;
        }

        public void addTermin(Termin t)
        {
            _TerminList.Add(t);
        }


    }
}
