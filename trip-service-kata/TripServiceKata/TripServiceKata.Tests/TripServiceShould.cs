using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using TripServiceKata.Exception;
using TripServiceKata.Trip;
using TripServiceKata.User;

namespace TripServiceKata.Tests
{
    [TestFixture]
    public class TripServiceShould
    {
        private static readonly User.User Guest = null;
        private static readonly User.User UnusedUser = null;
        private static readonly User.User AnotherUser = new User.User();
        private static readonly User.User RegisteredUser = new User.User();
        private static readonly Trip.Trip ToBrazil = new Trip.Trip();
        private static readonly Trip.Trip ToLondon = new Trip.Trip();

        private static User.User _loggedInUser;
        private TripService _tripService;
        private IUserSession _userSession;

        [SetUp]
        public void SetUp()
        {
            _loggedInUser = RegisteredUser;
            
            _userSession = Substitute.For<IUserSession>();
            _userSession.GetLoggedUser().Returns(_loggedInUser);

            _tripService = new TestableTripService(_userSession);
        }
        
        [Test]
        public void ShouldThrowAnExceptionsWhenUserIsNotLoggedIn()
        {
            _loggedInUser = Guest;
            _userSession.GetLoggedUser().Returns(_loggedInUser);
            
            Assert.Throws<UserNotLoggedInException>(
                () => _tripService.GetTripsByUser(UnusedUser));
        }

        [Test]
        public void ShouldNotReturnAnyTripsWhenUsersAreNotFriends()
        {
            var friend = new User.User();
            friend.AddFriend(AnotherUser);
            
            friend.AddTrip(ToBrazil);
            
            var friendTrips = _tripService.GetTripsByUser(friend);
            
            Assert.IsEmpty(friendTrips);
        }

        [Test]
        public void ShouldReturnTripsWhenUsersAreFriends()
        {
            var friend = new User.User();
            friend.AddFriend(_loggedInUser);
            friend.AddTrip(ToBrazil);
            friend.AddTrip(ToLondon);

            
            var friendTrips = _tripService.GetTripsByUser(friend);
            
            Assert.AreEqual(2, friendTrips.Count);
        }

        private class TestableTripService : TripService
        {
            public TestableTripService(IUserSession userSession) : base(userSession)
            {
            }

            protected override List<Trip.Trip> TripsBy(User.User user)
            {
                return user.Trips();
            }
        }
    }
}
