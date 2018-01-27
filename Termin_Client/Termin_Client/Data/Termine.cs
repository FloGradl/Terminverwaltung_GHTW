using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin_Client
{
    class Termine
    {
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }

        public Termine(DateTime date, string place, string topic, string description)
        {
            this.Date = date;
            this.Place = place;
            this.Topic = topic;
            this.Description = description;
        }

        public Termine(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jTermin = jObject["Termin"];
            Date = Convert.ToDateTime((string)jTermin["Date"]);
            Place = (string)jTermin["location"];
            Topic = (string)jTermin["theme"];
            Description = (string)jTermin["description"];
        }

        public override string ToString()
        {
            return Date + " " + Place + " " + Topic + " " + Description;
        }
    }
}
