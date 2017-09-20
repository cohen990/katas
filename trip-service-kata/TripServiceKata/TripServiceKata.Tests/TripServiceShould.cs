using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using TripServiceKata.Exception;
using TripServiceKata.Trip;

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

        private TripService _tripService;
        private ITripDAO _tripDao;

        [SetUp]
        public void SetUp()
        {

            _tripDao = Substitute.For<ITripDAO>();

            _tripService = new TripService(_tripDao);
        }

        [Test]
        public void ShouldThrowAnExceptionsWhenUserIsNotLoggedIn()
        {
            Assert.Throws<UserNotLoggedInException>(
                () => _tripService.GetFriendTrips(UnusedUser, Guest));
        }

        [Test]
        public void ShouldNotReturnAnyTripsWhenUsersAreNotFriends()
        {
            var friend = UserBuilder.User()
                .FriendsWith(AnotherUser)
                .WithTrips(ToBrazil)
                .Build();

            var friendTrips = _tripService.GetFriendTrips(friend, RegisteredUser);

            Assert.IsEmpty(friendTrips);
        }

        [Test]
        public void ShouldReturnTripsWhenUsersAreFriends()
        {
            var friend = UserBuilder.User()
                .FriendsWith(AnotherUser, RegisteredUser)
                .WithTrips(ToBrazil, ToLondon)
                .Build();

            _tripDao.TripsBy(friend).Returns(friend.Trips());
            var friendTrips = _tripService.GetFriendTrips(friend, RegisteredUser);

            Assert.AreEqual(2, friendTrips.Count);
        }
    }
}
