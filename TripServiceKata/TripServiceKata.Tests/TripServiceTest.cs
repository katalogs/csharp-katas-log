using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripServiceKata.Exception;
using TripServiceKata.Trip;
using TripServiceKata.User;

namespace TripServiceKata.Tests
{

    [TestClass]
    public partial class TripServiceTest
    {
        [TestMethod]
        public void Should_Throw_an_Exception_when_noOne_is_logged_in()
        {
            User.User loggedInUser = null;
            TripService service = new TestableTripService(loggedInUser);

            User.User aUser = new User.User();

            Assert.ThrowsException<UserNotLoggedInException>(() => service.GetTripsByUser(aUser));
        }

        [TestMethod]
        public void Should_return_empty_list_when_user_has_no_friends()
        {
            User.User loggedInUser = new User.User();
            TripService service = new TestableTripService(loggedInUser);

            User.User aUserWithoutFriends = new User.User();

            List<Trip.Trip> trips = service.GetTripsByUser(aUserWithoutFriends);

            Assert.IsTrue(!trips.Any());
        }

        [TestMethod]
        public void Should_return_empty_list_when_user_and_loggedIn_are_not_friends()
        {
            User.User loggedInUser = new User.User();
            TripService service = new TestableTripService(loggedInUser);

            User.User aUser = new User.User();
            User.User aFriend = new User.User();
            aUser.AddFriend(aFriend);
            Trip.Trip tripsA = new Trip.Trip();
            aUser.AddTrip(tripsA);

            List<Trip.Trip> trips = service.GetTripsByUser(aUser);

            Assert.IsTrue(!trips.Any());
        }

        [TestMethod]
        public void Should_return_specific_trips_when_loggedIn_and_User_are_friends()
        {
            User.User loggedInUser = new User.User();
            TripService service = new TestableTripService(loggedInUser);

            User.User aUser = new User.User();
            aUser.AddFriend(loggedInUser);
            Trip.Trip tripsA = new Trip.Trip();
            aUser.AddTrip(tripsA);

            List<Trip.Trip> trips = service.GetTripsByUser(aUser);

            Assert.IsTrue(trips.Contains(tripsA));
        }

    }

}
