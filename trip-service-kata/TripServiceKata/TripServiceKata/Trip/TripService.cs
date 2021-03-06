﻿using System.Collections.Generic;
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

        public List<Trip> GetFriendTrips(User.User friend, User.User loggedInUser)
        {
            Validate(loggedInUser);

            return friend.IsFriendsWith(loggedInUser)
                        ? _tripDAO.TripsBy(friend)
                        : NoTrips;
        }

        private static void Validate(User.User loggedInUser)
        {
            if (loggedInUser == null)
            {
                throw new UserNotLoggedInException();
            }
        }
    }
}
