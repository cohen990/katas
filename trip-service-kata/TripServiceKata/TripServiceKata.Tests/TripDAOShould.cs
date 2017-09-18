using NUnit.Framework;
using TripServiceKata.Exception;
using TripServiceKata.Trip;

namespace TripServiceKata.Tests
{
    [TestFixture]
    public class TripDAOShould
    {
        [Test]
        public void Throw_An_Exception_When_Retrieving_User_Trips()
        {
            Assert.Throws<DependendClassCallDuringUnitTestException>(
                () => new TripDAO().TripsBy(new User.User()));
        }
    }
}