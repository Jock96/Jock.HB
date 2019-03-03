namespace Jock.HB.UI.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using System.Configuration;
    using System.Data.SqlClient;

    [TestClass]
    public class DataBaseTest
    {
        [TestMethod]
        public void ConnectionUserDataBaseTest()
        {
            var userConnectionString = ConfigurationManager.ConnectionStrings["UserInfoConnection"].ConnectionString;

            var exceptionExist = false;
            var connectionExist = false;

            try
            {
                var connection = new SqlConnection(userConnectionString);
                connectionExist = true;
            }
            catch
            {
                exceptionExist = true;
            }

            Assert.AreNotEqual(exceptionExist, connectionExist);
        }

        [TestMethod]
        public void ConnectionHotelDataBaseTest()
        {
            var hotelConnectionString = ConfigurationManager.ConnectionStrings["HotelInfoConnection"].ConnectionString;

            var exceptionExist = false;
            var connectionExist = false;

            try
            {
                var connection = new SqlConnection(hotelConnectionString);
                connectionExist = true;
            }
            catch
            {
                exceptionExist = true;
            }

            Assert.AreNotEqual(exceptionExist, connectionExist);
        }
    }
}
