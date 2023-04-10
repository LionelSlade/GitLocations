using GeoLocations.Net.BL.DAO;
using GeoLocations.Net.BL.Enums;
using GeoLocations.Net.BL.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace GeoLocations.TL.BL.Net.UnitTests
{
    [TestClass]
    public class DAOTests
    {
        [TestMethod]
        public void GeoLocationObject()
        {

            ////"GEO_ID": "0500000US01001", "STATE": "01", "COUNTY": "001", "NAME": "Autauga", "LSAD": "County", "CENSUSAREA": 594.436000 }, "geometry": { "type": "Polygon", "coordinates": [ [ [ -86.496774, 32.344437 ], [ -86.717897, 32.402814 ], [ -86.814912, 32.340803 ], [ -86.890581, 32.502974 ], [ -86.917595, 32.664169 ], [ -86.713390, 32.661732 ], [ -86.714219, 32.705694 ], [ -86.413116, 32.707386 ], [ -86.411172, 32.409937 ], [ -86.496774, 32.344437 ] ] ] } }
            //GeoLocation geoLocation = new GeoLocation();
            //geoLocation.NAME = "Autauga";
            //Assert.AreEqual("Autauga", geoLocation.NAME);
            //geoLocation.GEO_ID = "0500000US01001";
            //Assert.AreEqual("0500000US01001", geoLocation.GEO_ID);
            //geoLocation.CENSUSAREA = "594.436000";
            //Assert.AreEqual("594.436000", geoLocation.CENSUSAREA);
            //geoLocation.COUNTY = "1";
            //Assert.AreEqual("1", geoLocation.COUNTY);
            //geoLocation.STATE = "01";
            //Assert.AreEqual("01", geoLocation.STATE);
            //geoLocation.LSAD = "1";
            //Assert.AreEqual("1", geoLocation.LSAD);
            //geoLocation.coordinates = "1";
            //Assert.AreEqual("1", geoLocation.coordinates);

            var myObjects = new CreateJsonObjects(enumJsonFileType.GeoLocations);
            GeoLocation.Root root = myObjects.GeoLocationsObject; //.features[0];
            var f1 = root.features[0];
            Assert.IsNotNull(f1);
            Assert.IsTrue(f1.properties.NAME == "Autauga");
            Assert.IsTrue(f1.properties.GEO_ID == "0500000US01001");
            Assert.IsTrue(f1.properties.CENSUSAREA == 594.436000);
            Assert.IsTrue(f1.properties.COUNTY == "001");
            Assert.IsTrue(f1.properties.STATE == "01");
            Assert.IsTrue(f1.properties.LSAD == "County");
            var g = root.features[0].geometry;
            var g1 = g.coordinates[0];
            Assert.IsTrue(g1.Count == 10);


        }

        [TestMethod]
        public void GeoCountryOutlineObject()
        {

            ////{ "ADMIN": "Aruba", "ISO_A3": "ABW" }, "geometry":}
            //CountryOutline geoCountryOutline = new CountryOutline()
            //{
            //    Name = "Aruba",
            //    ISOA3 = "ABW"
            //};

            //Assert.AreEqual("Aruba", geoCountryOutline.Name);
            //Assert.AreEqual("ABW", geoCountryOutline.ISOA3);
            var myObjects = new CreateJsonObjects(enumJsonFileType.CountryOutline);
            CountryOutline.Root countryOutlineRoot = myObjects.GeoCountryOutlinesObject;
            var f1 = countryOutlineRoot.features[0];
            Assert.IsNotNull(f1);
            Assert.IsTrue(f1.properties.ADMIN == "Aruba");
            Assert.IsTrue(f1.properties.ISO_A3 == "ABW");
            var g = countryOutlineRoot.features[0].geometry;
            var g1 = g.coordinates[0];  Assert.IsTrue(g1.Count==26);

        }
    }
}
