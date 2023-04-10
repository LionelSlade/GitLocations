using GeoLocations.Net.BL.Enums;
using GeoLocations.Net.BL.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeoLocations.UnitTests
{
    [TestClass]
    public class ConfigurationsTests
    {
        [TestMethod]
        public void CheckConfigurationGeoLocations()
        {
            var configuration = new Configuration();
            var configurations = configuration.Configurations;
            Assert.IsNotNull(configurations);
            Assert.IsTrue(configurations.Count > 0);
            var k = configurations[enumJsonFileType.GeoLocations];
            Assert.IsNotNull(k);
            Assert.IsTrue(k.Contains("geoLocations.geojson"));


        }
        [TestMethod]
        public void CheckConfigurationConnection()
        {
            var configuration = new Configuration();
            var configurations = configuration.Configurations;
            Assert.IsNotNull(configurations);
            Assert.IsTrue(configurations.Count > 0);
            var s = "ConnectionSTR";
            var val = configurations[enumJsonFileType.ConnectionSTR];
            Assert.IsNotNull(val.Contains("Data Source"));

        }
        [TestMethod]
        public void CheckConfigurationJsonFilePathCountryOutline()
        {
            var configuration = new Configuration();
            var configurations = configuration.Configurations;
            Assert.IsNotNull(configurations);
            Assert.IsTrue(configurations.Count > 0);
            var s = "JsonFilePath" + enumJsonFileType.CountryOutline.ToString();
            var val = configurations[enumJsonFileType.CountryOutline];
            Assert.IsNotNull(val.Contains("geoCountryOutlines.geojson"));

        }

        [TestMethod]
        public void CheckConfigurationJsonFilePathCapitals()
        {
            var configuration = new Configuration();
            var configurations = configuration.Configurations;
            Assert.IsNotNull(configurations);
            Assert.IsTrue(configurations.Count > 0);
            Assert.IsTrue(configurations.Count == 5);
            string s = "JsonFilePath" + enumJsonFileType.Capitals.ToString();
            Assert.IsTrue(s.Equals("JsonFilePathCapitals"));
            var val = configurations[enumJsonFileType.Capitals];
            Assert.IsNotNull(val.Contains("capitals.geojson"));

        }
    }
}
