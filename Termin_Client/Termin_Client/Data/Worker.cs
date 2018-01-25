using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin_Client.Data
{
    class Worker
    {
        public int bId { get; set; }
        public string bname { get; set; }
        public string email { get; set; }
        public string passwort { get; set; }
        public string telnr { get; set; }
        public int plz { get; set; }
        public string ort { get; set; }
        public string straße { get; set; }
        public int utId { get; set; }
        public int isGroupAdmin { get; set; }
        public int isSuperAdmin { get; set; }

        public Worker(string bname, string email, string telnr)
        {
            this.bname = bname;
            this.email = email;
            this.telnr = telnr;
        }
    }
}
