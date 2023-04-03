//using GeoLocations.Services;
using GeoLocations.Services;
using System.Diagnostics;
using System.Reflection;

namespace GeoLocations.Test
{
    [TestClass]
    public class Configurations
    {
        [TestMethod]
        public void CheckConfiguration()
        {
            Debug.WriteLine("Here");

            var configurations = new Configuration().Configurations;
            //Assert.IsNotNull(configurations);
            //Assert.IsTrue(configurations.Count() > 0);
            //var JsonFilePathGeoLocations = configurations[0];
            //Assert.IsNotNull(JsonFilePathGeoLocations.Contains("geoLocations.geojson"));

        }
    }
}
