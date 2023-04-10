using GeoLocations.Net.BL.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeoLocations.Net.BL.Enums;

namespace GeoLocations.UnitTests
{
    [TestClass]
    public class CreateObjectsT
    {
        [TestMethod]
        public void CreateObjectsTest()
        {
            var cJsonObjects = new CreateJsonObjects(enumJsonFileType.All);
            Assert.IsNotNull(cJsonObjects);  
            //Capitals                     
            Assert.IsTrue(cJsonObjects.CapitalsObject.Count == 250);
            Assert.IsNotNull(cJsonObjects.CapitalsObject);
            //CountryNames
            Assert.IsNotNull(cJsonObjects.CountryNamesObject);            
            Assert.IsTrue(cJsonObjects.CountryNamesObject.Count == 250);
            //GeoLocations
            Assert.IsNotNull(cJsonObjects.GeoLocationsObject);
            Assert.IsNotNull(cJsonObjects.GeoCountryOutlinesObject);
            //GeoCountyOutlines
            Assert.IsTrue(cJsonObjects.GeoCountryOutlinesObject.features.Count == 255);
            Assert.IsTrue(cJsonObjects.GeoLocationsObject.features.Count==8);

        }

        [TestMethod]
        public void CreateCapitals()
        {
            var cJsonObjects = new CreateJsonObjects(enumJsonFileType.Capitals);
            //Capitals                     
            Assert.IsTrue(cJsonObjects.CapitalsObject.Count == 250);
            Assert.IsNotNull(cJsonObjects.CapitalsObject);

        }
    }
}
