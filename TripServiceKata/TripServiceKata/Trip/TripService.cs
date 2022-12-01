using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User.User user)
        {
            User.User loggedUser = GetLoggedInUser();
            if (loggedUser == null)
                throw new UserNotLoggedInException();
        }

        protected virtual List<Trip> FindTripsByUser(User.User user) =>
            TripDAO.FindTripsByUser(user);

        protected virtual User.User GetLoggedInUser() =>
            UserSession.GetInstance().GetLoggedUser();
    }
}
