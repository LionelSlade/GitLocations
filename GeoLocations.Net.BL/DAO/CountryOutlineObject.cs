using System.Collections.Generic;

namespace GeoLocations.BL.Net.DAO
{
    public class CountryOutline
    {

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
            public List<List<List<object>>> coordinates { get; set; }
        }

        public class Properties
        {
            public string ADMIN { get; set; }
            public string ISO_A3 { get; set; }
        }

        public class Root
        {
            public string type { get; set; }
            public List<Feature> features { get; set; }
        }
    }
}