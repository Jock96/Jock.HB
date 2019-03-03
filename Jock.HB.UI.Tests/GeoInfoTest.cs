namespace Jock.HB.UI.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Jock.HB.UI.Utilities;

    [TestClass]
    public class GeoInfoTest
    {
        [TestMethod]
        public void GeoInfoHotelTest()
        {
            string ELEGANT_HOTEL = "Elegant Hotel";

            var geoInfoWorker = new GeoInfoHotels();
            var testNullString = "";

            Assert.AreNotEqual(geoInfoWorker.GetHotelMapPoint(ELEGANT_HOTEL), null);
            Assert.AreEqual(geoInfoWorker.GetHotelMapPoint(testNullString), null);
        }
    }
}
