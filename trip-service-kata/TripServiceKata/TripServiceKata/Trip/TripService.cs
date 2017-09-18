using System.Collections.Generic;
using TripServiceKata.Exception;

namespace TripServiceKata.Trip
{
    public class TripService
    {
        private static List<Trip> NoTrips => new List<Trip>();

        private readonly ITripDAO _tripDAO;

        public TripService(ITripDAO tripDao)
        {
            _tripDAO = tripDao;
        }

        public List<Trip> GetTripsByUser(User.User user, User.User loggedInUser)
        {
            if (loggedInUser == null)
            {
                throw new UserNotLoggedInException();
            }

            return user.IsFriendsWith(loggedInUser)
                        ? _tripDAO.TripsBy(user)
                        : NoTrips;
        }
    }
}
