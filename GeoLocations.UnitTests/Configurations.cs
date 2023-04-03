using GeoLocations.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeoLocations.UnitTests
{
    [TestClass]
    public class Configurations
    {
        [TestMethod]
        public void CheckConfigurationGeoLocations()
        {
            var configuration = new Services.Configuration();
            var configurations = configuration.Configurations;
            Assert.IsNotNull(configurations);
            Assert.IsTrue(configurations.Count > 0);
            var s = "JsonFilePath" + enumJsonFileType.GeoLocations.ToString();
            var JsonFilePathGeoLocations = configurations[s];
            Assert.IsNotNull(JsonFilePathGeoLocations.Contains("geoLocations.geojson"));

        }
        [TestMethod]
        public void CheckConfigurationConnection()
        {
            var configuration = new Services.Configuration();
            var configurations = configuration.Configurations;
            Assert.IsNotNull(configurations);
            Assert.IsTrue(configurations.Count > 0);
            var s = "ConnectionSTR";
            var val = configurations[s];
            Assert.IsNotNull(val.Contains("Data Source"));

        }
        [TestMethod]
        public void CheckConfigurationJsonFilePathCountryOutline()
        {
            var configuration = new Services.Configuration();
            var configurations = configuration.Configurations;
            Assert.IsNotNull(configurations);
            Assert.IsTrue(configurations.Count > 0);
            var s = "JsonFilePath" + enumJsonFileType.CountryOutline.ToString();
            var val = configurations[s];
            Assert.IsNotNull(val.Contains("geoCountryOutlines.geojson"));

        }

        [TestMethod]
        public void CheckConfigurationJsonFilePathCapitals()
        {
            var configuration = new Services.Configuration();
            var configurations = configuration.Configurations;
            Assert.IsNotNull(configurations);
            Assert.IsTrue(configurations.Count > 0);
            Assert.IsTrue(configurations.Count == 5);
            string s = "JsonFilePath" + enumJsonFileType.Capitals.ToString();
            //Assert.IsTrue(s.Equals("JsonFilePathCapitals"));
            //var s = "JsonFilePathCapitals";
            Assert.IsTrue(s.Equals("JsonFilePathCapitals"));
            var val = configurations[s];
            Assert.IsNotNull(val.Contains("capitals.geojson"));

            //JsonFilePathCaptials

        }
    }
}
