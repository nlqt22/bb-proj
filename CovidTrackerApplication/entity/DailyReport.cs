using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace CovidTrackerApplication.entity
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class DailyReport
    {
        [JsonProperty("total")]
        public Total Total { get; set; }

        [JsonProperty("today")]
        public Today Today { get; set; }

        [JsonProperty("overview")]
        public List<Overview> Overview { get; set; }

        [JsonProperty("locations")]
        public List<Location> Locations { get; set; }
    }

    public class Internal
    {
        [JsonProperty("death")]
        public int Death { get; set; }

        [JsonProperty("treating")]
        public int Treating { get; set; }

        [JsonProperty("cases")]
        public int Cases { get; set; }

        [JsonProperty("recovered")]
        public int Recovered { get; set; }
    }

    public class Location
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("death")]
        public int Death { get; set; }

        [JsonProperty("treating")]
        public int Treating { get; set; }

        [JsonProperty("cases")]
        public int Cases { get; set; }

        [JsonProperty("recovered")]
        public int Recovered { get; set; }

        [JsonProperty("casesToday")]
        public int CasesToday { get; set; }
    }

    public class Overview
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("death")]
        public int Death { get; set; }

        [JsonProperty("treating")]
        public int Treating { get; set; }

        [JsonProperty("cases")]
        public int Cases { get; set; }

        [JsonProperty("recovered")]
        public int Recovered { get; set; }

        [JsonProperty("avgCases7day")]
        public int AvgCases7day { get; set; }

        [JsonProperty("avgRecovered7day")]
        public int AvgRecovered7day { get; set; }

        [JsonProperty("avgDeath7day")]
        public int AvgDeath7day { get; set; }
    }

    public class Today
    {
        [JsonProperty("internal")]
        public Internal Internal { get; set; }

        [JsonProperty("world")]
        public World World { get; set; }
    }

    public class Total
    {
        [JsonProperty("internal")]
        public Internal Internal { get; set; }

        [JsonProperty("world")]
        public World World { get; set; }
    }

    public class World
    {
        [JsonProperty("death")]
        public int Death { get; set; }

        [JsonProperty("treating")]
        public int Treating { get; set; }

        [JsonProperty("cases")]
        public int Cases { get; set; }

        [JsonProperty("recovered")]
        public int Recovered { get; set; }
    }


}
