using System.Collections.Generic;
using TripServiceKata.Trip;

namespace TripServiceKata.Tests
{

    public partial class TripServiceTest
    {
        public class TestableTripService : TripService
        {
            private readonly User.User _loggedInUser;

            public TestableTripService(User.User loggedInUser)
                => _loggedInUser = loggedInUser;

            protected override User.User GetLoggedUser()
                => _loggedInUser;

            protected override List<Trip.Trip> FindTripsByUser(User.User user)
                => user.Trips();
        }
    }

}
