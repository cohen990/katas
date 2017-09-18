using NUnit.Framework;

namespace TripServiceKata.Tests
{
    [TestFixture]
    public class UserShould
    {
        private readonly User.User Bob = new User.User();
        private readonly User.User Paul = new User.User();

        [Test]
        public void Inform_When_Users_Are_Not_Friends()
        {
            var user = UserBuilder.User()
                .FriendsWith(Bob)
                .Build();

            Assert.That(user.IsFriendsWith(Paul), Is.False);
        }

        [Test]
        public void Inform_When_Users_Are_Friends()
        {
            var user = UserBuilder.User()
                .FriendsWith(Bob, Paul)
                .Build();

            Assert.That(user.IsFriendsWith(Bob), Is.True);
        }
    }
}