using System.Collections.Generic;
using TripServiceKata.Exception;

namespace TripServiceKata.Trip
{
    public class TripService
    {
        private TripDAO _tripDao;

        public TripService(TripDAO tripDao)
        {
            _tripDao = tripDao;
        }

        public List<Trip> GetTripsByUser(User.User loggedUser, User.User user)
        {
            if (loggedUser == null)
            {
                throw new UserNotLoggedInException();
            }

            return user.IsFriendWith(loggedUser) ? _tripDao.FindTripsByUserImplem(user) : new List<Trip>();
        }
    }
}
