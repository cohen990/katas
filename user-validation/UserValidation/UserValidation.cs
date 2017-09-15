using System.Collections.Generic;

namespace UserValidation
{
    public class UserValidation
    {
        private readonly IEnumerable<UserValidator> _validators;

        public UserValidation(IEnumerable<UserValidator> validators)
        {
            _validators = validators;
        }

        public void Validate(User user)
        {
            foreach (var validator in _validators)
            {
                validator.Validate(user);
            }
        }
    }
}