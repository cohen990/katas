using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User.User user)
        {
            if (GetLoggedInUser() == null)
            {
                throw new UserNotLoggedInException();
            }

            return user.IsFriendsWith(GetLoggedInUser())
                        ? TripsBy(user)
                        : NoTrips();
        }

        protected virtual User.User GetLoggedInUser()
        {
            return UserSession.GetInstance().GetLoggedInUser();
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
