namespace GeoLocations.Net.BL.DAO
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class CountryName
    {
        public class Center
        {
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string zoom { get; set; }
        }

        public class Root
        {
            public static dynamic Id { get; internal set; }
            public string id { get; set; }
            public bool enabled { get; set; }
            public string code3l { get; set; }
            public string code2l { get; set; }
            public string name { get; set; }
            public string name_official { get; set; }
            public Center center { get; set; }
            public object names { get; set; }
        }
    }

}
