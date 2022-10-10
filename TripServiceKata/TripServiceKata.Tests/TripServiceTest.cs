using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.Trip;
using TripServiceKata.User;

namespace TripServiceKata.Tests
{
    [TestClass]
    public class TripServiceTest
    {
        [TestMethod]
        public void UserNotLoggedInThrowAnException()
        {
            var user = UserBuilder.AUser().Build();
            TripService tripServiceWithoutLoggedInUser = new TestableTripService(default);

            Assert.ThrowsException<UserNotLoggedInException>(() =>
                tripServiceWithoutLoggedInUser.GetTripsByUser(user));
        }
        
        [TestMethod]
        public void UserWithoutFriends()
        {
            var userWithoutFriends = UserBuilder.AUser().Build();
            TripService tripServiceLoggedInUser = new TestableTripService(UserBuilder.AUser().Build());

            var result =
                tripServiceLoggedInUser.GetTripsByUser(userWithoutFriends);

            result.Should().BeEmpty();
        }
        
        [TestMethod]
        public void UserWithFriendsButWihtNotLoggedInUser()
        {

            User.User aFriend = UserBuilder.AUser().Build();
            User.User loggedInUser = UserBuilder.AUser().Build();
            Trip.Trip trip = new Trip.Trip();

            var userWithFriends = UserBuilder.AUser()
                .FriendWith(aFriend)
                .WithTrips(trip)
                .Build();


            TripService tripServiceLoggedInUser = new TestableTripService(loggedInUser);

            var result =
                tripServiceLoggedInUser.GetTripsByUser(userWithFriends);

            result.Should().BeEmpty();
        }
        
        [TestMethod]
        public void UserWithFriendsWihtLoggedInUser()
        {
            User.User loggedInUser = UserBuilder.AUser().Build();
            Trip.Trip trip = new Trip.Trip();

            var userWithFriends = UserBuilder.AUser()
                .FriendWith(loggedInUser)
                .WithTrips(trip)
                .Build();


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
