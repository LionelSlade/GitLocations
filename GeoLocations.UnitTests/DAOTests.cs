using GeoLocations.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace GeoLocations.UnitTests
{
    [TestClass]
    public class DAOTests
    {
        [TestMethod]
        public void GeoLocationObject()
        {

            //"GEO_ID": "0500000US01001", "STATE": "01", "COUNTY": "001", "NAME": "Autauga", "LSAD": "County", "CENSUSAREA": 594.436000 }, "geometry": { "type": "Polygon", "coordinates": [ [ [ -86.496774, 32.344437 ], [ -86.717897, 32.402814 ], [ -86.814912, 32.340803 ], [ -86.890581, 32.502974 ], [ -86.917595, 32.664169 ], [ -86.713390, 32.661732 ], [ -86.714219, 32.705694 ], [ -86.413116, 32.707386 ], [ -86.411172, 32.409937 ], [ -86.496774, 32.344437 ] ] ] } }
            GeoLocation geoLocation = new GeoLocation();
            geoLocation.NAME = "Autauga";
            Assert.AreEqual("Autauga", geoLocation.NAME);
            geoLocation.GEO_ID = "0500000US01001";
            Assert.AreEqual("0500000US01001", geoLocation.GEO_ID);
            geoLocation.CENSUSAREA = "594.436000";
            Assert.AreEqual("594.436000", geoLocation.CENSUSAREA);
            geoLocation.COUNTY = "1";
            Assert.AreEqual("1", geoLocation.COUNTY);
            geoLocation.STATE = "01";
            Assert.AreEqual("01", geoLocation.STATE);
            geoLocation.LSAD = "1";
            Assert.AreEqual("1", geoLocation.LSAD);
            geoLocation.coordinates = "1";
            Assert.AreEqual("1", geoLocation.coordinates);

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

        }
    }
}
