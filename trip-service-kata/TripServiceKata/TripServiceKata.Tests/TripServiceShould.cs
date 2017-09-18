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
            _userSession.GetLoggedInUser().Returns(_loggedInUser);

            _tripService = new TestableTripService(_userSession);
        }
        
        [Test]
        public void ShouldThrowAnExceptionsWhenUserIsNotLoggedIn()
        {
            _loggedInUser = Guest;
            _userSession.GetLoggedInUser().Returns(_loggedInUser);
            
            Assert.Throws<UserNotLoggedInException>(
                () => _tripService.GetTripsByUser(UnusedUser));
        }

        [Test]
        public void ShouldNotReturnAnyTripsWhenUsersAreNotFriends()
        {
            var friend = UserBuilder.User()
                .FriendsWith(AnotherUser)
                .WithTrips(ToBrazil)
                .Build();
            
            var friendTrips = _tripService.GetTripsByUser(friend);
            
            Assert.IsEmpty(friendTrips);
        }

        [Test]
        public void ShouldReturnTripsWhenUsersAreFriends()
        {
            var friend = UserBuilder.User()
                .FriendsWith(AnotherUser, _loggedInUser)
                .WithTrips(ToBrazil, ToLondon)
                .Build();
            
            var friendTrips = _tripService.GetTripsByUser(friend);
            
            Assert.AreEqual(2, friendTrips.Count);
        }

        private class TestableTripService : TripService
        {
            protected override User.User GetLoggedInUser()
            {
                return _loggedInUser;
            }
            
            protected override List<Trip.Trip> TripsBy(User.User user)
            {
                return user.Trips();
            }
        }
    }
}
