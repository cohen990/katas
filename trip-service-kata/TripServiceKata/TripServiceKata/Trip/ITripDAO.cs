using System.Collections.Generic;

namespace TripServiceKata.Trip
{
    public interface ITripDAO
    {
        List<Trip> TripsBy(User.User user);
    }
}