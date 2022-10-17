using System;
using System.Collections.Generic;
using TripServiceKata.Exception;

namespace TripServiceKata.Trip
{
    public class TripDAO
    {
        [Obsolete("Utilisé la méthode non statique !")]
        public static List<Trip> FindTripsByUser(User.User user)
        {
            throw new DependendClassCallDuringUnitTestException(
                        "TripDAO should not be invoked on an unit test.");
        }
        
        public virtual List<Trip> FindTripsByUserNonStatic(User.User user)
        {
            return FindTripsByUser(user);
        }
    }
}
