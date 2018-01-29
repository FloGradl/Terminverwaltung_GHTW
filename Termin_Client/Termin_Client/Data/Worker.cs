// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Termin_Client.Data;
//
//    var data = Worker.FromJson(jsonString);

namespace Termin_Client.Data
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public partial class Worker
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("isGroupAdmin")]
        public bool IsGroupAdmin { get; set; }

        [JsonProperty("isSuperAdmin")]
        public bool IsSuperAdmin { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("plz")]
        public long Plz { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("telnr")]
        public string Telnr { get; set; }

        public Worker(string bname, string email, string telnr)
        {
            this.Name = bname;
            this.Email = email;
            this.Telnr = telnr;
        }
    }

    public partial class Worker
    {
        public static List<Worker> FromJson(string json) => JsonConvert.DeserializeObject<List<Worker>>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<Worker> self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
