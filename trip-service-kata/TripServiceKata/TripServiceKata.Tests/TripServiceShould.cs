﻿using System.Collections.Generic;
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

        [SetUp]
        public void SetUp()
        {
            _tripService = new TestableTripService();
        }
        
        [Test]
        public void ShouldThrowAnExceptionsWhenUserIsNotLoggedIn()
        {
            Assert.Throws<UserNotLoggedInException>(
                () => _tripService.GetTripsByUser(UnusedUser, Guest));
        }

        [Test]
        public void ShouldNotReturnAnyTripsWhenUsersAreNotFriends()
        {
            var friend = UserBuilder.User()
                .FriendsWith(AnotherUser)
                .WithTrips(ToBrazil)
                .Build();
            
            var friendTrips = _tripService.GetTripsByUser(friend, RegisteredUser);
            
            Assert.IsEmpty(friendTrips);
        }

        [Test]
        public void ShouldReturnTripsWhenUsersAreFriends()
        {
            var friend = UserBuilder.User()
                .FriendsWith(AnotherUser, RegisteredUser)
                .WithTrips(ToBrazil, ToLondon)
                .Build();
            
            var friendTrips = _tripService.GetTripsByUser(friend, RegisteredUser);
            
            Assert.AreEqual(2, friendTrips.Count);
        }

        private class TestableTripService : TripService
        {
            protected override List<Trip.Trip> TripsBy(User.User user)
            {
                return user.Trips();
            }
        }
    }
}
