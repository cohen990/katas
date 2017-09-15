namespace UserValidation
{
    public class NameValidator : UserValidator
    {
        public void Validate(User user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName))
            {
                throw new ValidationException("First name cannot be empty");
            }
            if(string.IsNullOrWhiteSpace(user.LastName))
            {
                throw new ValidationException("Last name cannot be empty");
            }
        }
    }
}