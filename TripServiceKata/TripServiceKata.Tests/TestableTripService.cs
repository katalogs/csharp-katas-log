using System.Collections.Generic;
using TripServiceKata.Trip;

namespace TripServiceKata.Tests
{
    internal class TestableTripService : TripService
    {
        public User.User LoggedInUser { get; set; }
        public List<Trip.Trip> ExpectedTrips { get; set; }

        protected override User.User GetLoggedInUser() => LoggedInUser;

        protected override List<Trip.Trip> FindTripsByUser(User.User user) => ExpectedTrips;
    }
}
