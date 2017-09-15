using System.Collections.Generic;
using UserValidation;
using Xunit;

namespace UserValidationTests
{
    public class UserServiceShould
    {
        [Fact]
        public void SuccessfulyCreateAValidUser()
        {
            var user = new User("firstName", "lastName", "email@address.com", 19);
            
            Create(user);
        }
        
        [Fact]
        public void FailToCreateAUserWithoutAFirstName()
        {
            var user = new User("", "lastName", "email@address.com", 19);
            
            Assert.Throws<ValidationException>(() => Create(user));
        }

        [Fact]
        public void FailToCreateAUserWithoutALastName()
        {
            var user = new User("firstName", "", "email@address.com", 19);

            Assert.Throws<ValidationException>(() => Create(user));
        }

        [Fact]
        public void FailToCreateAUserWithAnInvalidEmailAddress()
        {
            var user = new User("firstName", "lastName", "emailaddress", 19);

            Assert.Throws<ValidationException>(() => Create(user));
        }

        [Fact]
        public void FailToCreateAUserWhoIsTooYoung()
        {
            var user = new User("firstName", "lastName", "email@address.com", 17);

            Assert.Throws<ValidationException>(() => Create(user));
        }

        private void Create(User user)
        {
            var validation = new UserValidation.UserValidation(new List<UserValidator>
            {
                new NameValidator(),
                new EmailAddressValidator(),
                new AgeValidator()
            });
            
            var repository = new UserRepository();
            
            var userService = new UserService(validation, repository);

            userService.CreateUser(user);
        }
    }
}
