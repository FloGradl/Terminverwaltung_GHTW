using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin_Client.Data
{
    class Car
    {
        public String Numberplate { get; set; }
        public String Description { get; set; }
        public List<int> Position { get; set; }
        
        public Car(string numberplate, string description, List<int> position)
        {
            this.Numberplate = numberplate;
            this.Description = description;
            this.Position = position;
        }

        public Car(string numberplate, string description)
        {
            this.Numberplate = numberplate;
            this.Description = description;
        }
    }
}
