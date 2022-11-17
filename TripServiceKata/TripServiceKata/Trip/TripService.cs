using System.Collections.Generic;
using System.Linq;
using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User.User user)
        {
            User.User loggedUser = GetLoggedUser();
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

        protected virtual User.User GetLoggedUser()
        {
            return UserSession.GetInstance().GetLoggedUser();
        }
    }
}
