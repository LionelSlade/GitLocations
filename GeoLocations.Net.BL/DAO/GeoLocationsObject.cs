using Newtonsoft.Json;
using System.Collections.Generic;

namespace GeoLocations.Net.BL.DAO
{

    public class GeoLocation
    {
        //public string GEO_ID { get; set; }
        //public string STATE { get; set; }
        //public string COUNTY { get; set; }
        //public string NAME { get; set; }
        //public string LSAD { get; set; }
        //public string CENSUSAREA { get; set; }
        //public string coordinates { get; set; }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Feature
        {
            public string type { get; set; }
            public Properties properties { get; set; }
            public Geometry geometry { get; set; }
        }

        public class Geometry
        {
            public string type { get; set; }
            public List<List<List<double>>> coordinates { get; set; }
        }

        public class Properties
        {
            public string GEO_ID { get; set; }
            public string STATE { get; set; }
            public string COUNTY { get; set; }
            public string NAME { get; set; }
            public string LSAD { get; set; }
            public double CENSUSAREA { get; set; }
        }

        public class Root
        {
            public string type { get; set; }
            public List<Feature> features { get; set; }
        }
    }
}
