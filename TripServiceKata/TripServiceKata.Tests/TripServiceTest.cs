using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripServiceKata.Exception;
using TripServiceKata.Trip;

namespace TripServiceKata.Tests
{
    [TestClass]
    public class TripServiceTest
    {
        [TestMethod]
        public void UserNotLoggedInThrowAnException()
        {
            var user = new User.User();
            TripService tripServiceWithoutLoggedInUser = new TestableTripService(default);

            Assert.ThrowsException<UserNotLoggedInException>(() =>
                tripServiceWithoutLoggedInUser.GetTripsByUser(user));
        }
        
        [TestMethod]
        public void UserWithoutFriends()
        {
            var userWithoutFriends = new User.User();
            TripService tripServiceLoggedInUser = new TestableTripService(new User.User());

            var result =
                tripServiceLoggedInUser.GetTripsByUser(userWithoutFriends);

            result.Should().BeEmpty();
        }
        
        [TestMethod]
        public void UserWithFriendsButWihtNotLoggedInUser()
        {
            var userWithFriends = new User.User();
            User.User aFriend = new User.User();
            userWithFriends.AddFriend(aFriend);
            User.User loggedInUser = new User.User();
            TripService tripServiceLoggedInUser = new TestableTripService(loggedInUser);

            var result =
                tripServiceLoggedInUser.GetTripsByUser(userWithFriends);

            result.Should().BeEmpty();
        }
        
        [TestMethod]
        public void UserWithFriendsWihtLoggedInUser()
        {
            var userWithFriends = new User.User();
            User.User loggedInUser = new User.User();
            userWithFriends.AddFriend(loggedInUser);
            Trip.Trip trip = new Trip.Trip();
            userWithFriends.AddTrip(trip);
            TripService tripServiceLoggedInUser = new TestableTripService(loggedInUser);

            var result =
                tripServiceLoggedInUser.GetTripsByUser(userWithFriends);

            result.Should().NotBeEmpty();
            result.Should().Contain(trip);
        }

        public class TestableTripService : TripService
        {
            private User.User loggedInUser;

            public TestableTripService(User.User inUser)
            {
                loggedInUser = inUser;
            }

            protected override User.User GetLoggedUser()
            {
                return loggedInUser;
            }

            protected override List<Trip.Trip> FindTripsByUser(User.User user)
            {
                return user.Trips();
            }
        }
    }
}
