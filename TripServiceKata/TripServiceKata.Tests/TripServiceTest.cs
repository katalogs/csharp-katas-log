using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripServiceKata.Exception;
using TripServiceKata.Trip;

namespace TripServiceKata.Tests
{
    [TestClass]
    public class TripServiceTest
    {
        private TestableTripService _tripService;

        public TripServiceTest()
        {
            _tripService = new TestableTripService
            {
                LoggedInUser = new User.User(),
                ExpectedTrips = new List<Trip.Trip> { new Trip.Trip() }
            };
        }

        [TestMethod]
        public void TestWithNoUserLoggedIn_ShouldThrowException()
        {
            _tripService.LoggedInUser = null;

            Assert.ThrowsException<UserNotLoggedInException>(
                () => _tripService.GetTripsByUser(new User.User()));
        }

        [TestMethod]
        public void TestWithNoFriend_ShouldReturnEmptyList()
        {
            var list = _tripService.GetTripsByUser(new User.User());

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void TestWithTwoUsersThatAreNotFriends_ShouldReturnEmptyList()
        {
            var user = new User.User();
            user.AddFriend(new User.User());

            var list = _tripService.GetTripsByUser(user);

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void TestWithTwoUsersThatAreFriends_ShouldReturnTripList()
        {
            var user = new User.User();
            user.AddFriend(_tripService.LoggedInUser);

            var list = _tripService.GetTripsByUser(user);

            Assert.AreEqual(1, list.Count);
        }
    }
}
