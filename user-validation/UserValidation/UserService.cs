namespace UserValidation
{
    public class UserService
    {
        private readonly UserValidation _validation;
        private readonly UserRepository _repository;

        public UserService(UserValidation validation, UserRepository repository)
        {
            _validation = validation;
            _repository = repository;
        }
        
        public void CreateUser(User user)
        {
            _validation.Validate(user);
            _repository.Create(user);
        }
    }
}
