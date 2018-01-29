using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin_Client.Data
{
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using Termin_Client.Data;
    //
    //    var data = Car.FromJson(jsonString);
        public partial class Car
        {
            [JsonProperty("fid")]
            public long Fid { get; set; }

            [JsonProperty("licensePlate")]
            public string LicensePlate { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("uid")]
            public long Uid { get; set; }


            //public Car(string numberplate, string description, List<int> position)
            //{
            //    this.LicensePlate = numberplate;
            //    this.Description = description;
            //    this.Position = position;
            //}

            public Car(string numberplate, string description)
            {
                this.LicensePlate = numberplate;
                this.Description = description;
            }
        }

        public partial class Car
        {
            public static List<Car> FromJson(string json) => JsonConvert.DeserializeObject<List<Car>>(json, Converter.Settings);
        }
}
