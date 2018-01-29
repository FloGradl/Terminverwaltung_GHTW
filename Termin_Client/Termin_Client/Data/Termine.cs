// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Termin_Client.Data;
//
//    var data = Termine.FromJson(jsonString);

namespace Termin_Client.Data
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public partial class Termine
    {
        //lei orsch
        private DateTime dateTime;
        private string text1;
        private string text2;
        private string v;

        public Termine(DateTime dateTime, string text1, string text2, string v)
        {
            this.dateTime = dateTime;
            this.text1 = text1;
            this.text2 = text2;
            this.v = v;
        }
        //bis do

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("date")]
        public Date Date { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("theme")]
        public string Theme { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("usersParticipating")]
        public List<UsersParticipating> UsersParticipating { get; set; }

        //public Termine(DateTime d, string ort, string info, string beschreibung)
        //{
        //    this.Date.Day = d.Day;
        //    this.Date.Month = d.Month;
        //    this.Date.Year = d.Year;
        //    this.Location = ort;
        //    this.Theme = info;
        //    this.Description = beschreibung;
        //}
    }

    public partial class Date
    {
        [JsonProperty("year")]
        public long Year { get; set; }

        [JsonProperty("month")]
        public long Month { get; set; }

        [JsonProperty("day")]
        public long Day { get; set; }

        public override string ToString()
        {
            return Day + "." + Month + "." + Year;
        }
    }

    public partial class UsersParticipating
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("telnr")]
        public string Telnr { get; set; }

        [JsonProperty("plz")]
        public long Plz { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("isSuperAdmin")]
        public bool IsSuperAdmin { get; set; }

        [JsonProperty("isGroupAdmin")]
        public bool IsGroupAdmin { get; set; }
    }

    public partial class Termine
    {
        public static List<Termine> FromJson(string json) => JsonConvert.DeserializeObject<List<Termine>>(json, Converter.Settings);
    }
}
