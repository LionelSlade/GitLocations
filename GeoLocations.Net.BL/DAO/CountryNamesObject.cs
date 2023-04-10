namespace GeoLocations.BL.Net.DAO
{
    public class CountryNames
    {
        public string ID { get;  set; }
        public bool ENABLED { get; set; }
        public string CODE3L { get; set; }
        public string CODE2L { get; set; }
        public string NAME { get; set; }
        public string NAME_OFFICAL { get; set; }        
                
        public object NAMES { get; set; }
        public string coordinates { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string zoom { get; set; }


        // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
        public class Center
        {
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string zoom { get; set; }
        }

        public class Root
        {
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
