namespace TripServiceKata.Tests
{
    public class UserBuilder
    {
        private readonly User.User _user;
        private User.User[] _friends = new User.User[0];
        private Trip.Trip[] _trips = new Trip.Trip[0];

        private UserBuilder()
        {
            _user = new User.User();
        }
        
        public static UserBuilder User()
        {
            return new UserBuilder(); 
        }
        
        public UserBuilder FriendsWith(params User.User[] friends)
        {
            _friends = friends;
            return this;
        }

        public UserBuilder WithTrips(params Trip.Trip[] trips)
        {
            _trips = trips;
            return this;
        }

        public User.User Build()
        {
            var user = new User.User();
            AddFriendsTo(user);
            AddTripsTo(user);
            return user;
        }

        private void AddTripsTo(User.User user)
        {
            foreach (var trip in _trips)
            {
                user.AddTrip(trip);
            }
        }

        private void AddFriendsTo(User.User user)
        {
            foreach (var friend in _friends)
            {
                user.AddFriend(friend);
            }
        }
    }
}