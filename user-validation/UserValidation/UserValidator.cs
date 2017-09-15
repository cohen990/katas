namespace UserValidation
{
    public interface UserValidator
    {
        void Validate(User user);
    }

    public class AgeValidator : UserValidator
    {
        public void Validate(User user)
        {
            if (user.Age < 18)
            {
                throw new ValidationException("User is too young. Must be over 18.");
            }
        }
    }
}