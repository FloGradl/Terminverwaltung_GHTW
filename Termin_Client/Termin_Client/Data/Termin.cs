using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin_Client.Data
{
    class Termin
    {
        List<Termin> terminList;
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }

        public Termin(DateTime date, string place, string topic, string description)
        {
            this.Date = date;
            this.Place = place;
            this.Topic = topic;
            this.Description = description;
        }
    }
}
