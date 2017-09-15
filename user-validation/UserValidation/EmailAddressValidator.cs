namespace UserValidation
{
    public class EmailAddressValidator : UserValidator
    {
        public void Validate(User user)
        {
            if (!user.EmailAddress.Contains("@"))
            {
                throw new ValidationException("email address must be of the form 'username@domain.tld");
            }
        }
    }
}