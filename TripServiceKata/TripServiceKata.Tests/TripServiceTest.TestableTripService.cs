using System.Collections.Generic;
using TripServiceKata.Trip;

namespace TripServiceKata.Tests
{

    public partial class TripServiceTest
    {
        public class TestableTripService : TripService
        {
            protected override List<Trip.Trip> FindTripsByUser(User.User user)
                => user.Trips();
        }
    }

}
