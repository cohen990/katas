using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
    public class TripService
    {
        private readonly IUserSession _userSession;

        protected TripService(IUserSession userSession)
        {
            _userSession = userSession;
        }

        public List<Trip> GetTripsByUser(User.User user)
        {
            if (_userSession.GetLoggedInUser() == null)
            {
                throw new UserNotLoggedInException();
            }

            return user.IsFriendsWith(_userSession.GetLoggedInUser())
                        ? TripsBy(user)
                        : NoTrips();
        }

        protected virtual List<Trip> TripsBy(User.User user)
        {
            var tripList = TripDAO.FindTripsByUser(user);
            return tripList;
        }

        private static List<Trip> NoTrips()
        {
            return new List<Trip>();
        }
    }
}
