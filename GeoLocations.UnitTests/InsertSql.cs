using GeoLocations.Enums;
using GeoLocations.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeoLocations.UnitTests
{
    [TestClass]
    public class InsertSql
    {
        [TestMethod]
        public void InsertGeoLocations()
        {
            var configuaration = new Configuration().Configurations;
            var ijTS = new InsertJsonToSql();
            var result = ijTS.Execute(configuaration["JsonFilePathGeoLocations"], enumJsonFileType.GeoLocations);
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InsertCountryOutline()
        {
            var configuaration = new Configuration().Configurations;
            var ijTS = new InsertJsonToSql();
            var result = ijTS.Execute(configuaration["JsonFilePathCountryOutline"], enumJsonFileType.CountryOutline);
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InsertCountryNamesOutline()
        {
            var configuaration = new Configuration().Configurations;
            var ijTS = new InsertJsonToSql();
            var result = ijTS.Execute(configuaration["JsonFilePathCountryNames"], enumJsonFileType.CountryNames);
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InsertCapitals()
        {
            var configuaration = new Configuration().Configurations;
            var ijTS = new InsertJsonToSql();
            //var result = ijTS.Execute(configuaration[enumJsonFileType.Capitals.ToString()], enumJsonFileType.Capitals);
            var result = ijTS.Execute(configuaration["JsonFilePathCapitals"], enumJsonFileType.Capitals);
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }
    }
}
