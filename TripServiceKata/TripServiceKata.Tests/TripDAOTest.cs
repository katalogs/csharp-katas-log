using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripServiceKata.Exception;
using TripServiceKata.Trip;

namespace TripServiceKata.Tests
{

    [TestClass]
    public class TripAOTest
    {
        [TestMethod]
        public void should_work_with_static()
        {
            User.User user = new User.User();
            
            Assert.ThrowsException<DependendClassCallDuringUnitTestException>(() => TripDAO.FindTripsByUser(user));
        }
        
        [TestMethod]
        public void should_work_as_static_with_implem()
        {
            User.User user = new User.User();

            TripDAO tripDao = new TripDAO();
            Assert.ThrowsException<DependendClassCallDuringUnitTestException>(() => tripDao.FindTripsByUserImplem(user));
        }

       
    }
}
