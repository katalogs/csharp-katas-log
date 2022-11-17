using System.Collections.Generic;
using TripServiceKata.Exception;

namespace TripServiceKata.Trip
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User.User loggedUser, User.User user)
        {
            if (loggedUser == null)
            {
                throw new UserNotLoggedInException();
            }

            return user.IsFriendWith(loggedUser) ? FindTripsByUser(user) : new List<Trip>();
        }

        protected virtual List<Trip> FindTripsByUser(User.User user)
        {
            return TripDAO.FindTripsByUser(user);
        }
    }
}
