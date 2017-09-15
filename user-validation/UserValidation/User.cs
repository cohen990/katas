namespace UserValidation
{
    public class User
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string EmailAddress { get; }
        public int Age { get; }

        public User(string firstName, string lastName, string emailAddress, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            Age = age;
        }
    }
}