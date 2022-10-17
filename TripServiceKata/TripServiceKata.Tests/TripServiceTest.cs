using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using TripServiceKata.Exception;
using TripServiceKata.Trip;
using TripServiceKata.User;

namespace TripServiceKata.Tests
{
    [TestClass]
    public class TripServiceTest
    {
        private Mock<TripDAO> _tripDaoMock = new Mock<TripDAO>();
        
        [TestMethod]
        public void UserNotLoggedInThrowAnException()
        {
            var user = UserBuilder.AUser().Build();
            
            TripService tripServiceWithoutLoggedInUser = new TestableTripService(default, _tripDaoMock.Object);

            Assert.ThrowsException<UserNotLoggedInException>(() =>
                tripServiceWithoutLoggedInUser.GetTripsByUser(user));
        }
        
        [TestMethod]
        public void UserWithoutFriends()
        {
            var userWithoutFriends = UserBuilder.AUser().Build();
            TripService tripServiceLoggedInUser = new TestableTripService(UserBuilder.AUser().Build(), _tripDaoMock.Object);

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


            TripService tripServiceLoggedInUser = new TestableTripService(loggedInUser, _tripDaoMock.Object);

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
            
            _tripDaoMock
                .Setup(t => t.FindTripsByUserNonStatic(It.IsAny<User.User>()))
                .Returns(new List<Trip.Trip>{trip});

            TripService tripServiceLoggedInUser = new TestableTripService(loggedInUser, _tripDaoMock.Object);

            var result =
                tripServiceLoggedInUser.GetTripsByUser(userWithFriends);

            result.Should().NotBeEmpty();
            result.Should().Contain(trip);
        }

        public class TestableTripService : TripService
        {
            private User.User loggedInUser;

            public TestableTripService(User.User inUser, TripDAO tripDao) : base(tripDao)
            {
                loggedInUser = inUser;
            }

            protected override User.User GetLoggedUser()
            {
                return loggedInUser;
            }
        }
    }
}
