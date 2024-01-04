


namespace TDD_UserManagement
{
    internal class UserManagement
    {

        internal static List<User> _users = new List<User>();
        private UserValidator _userValidator;

        User? FindByPhone(string phone) => _users.Where(x => x.Phone == phone).FirstOrDefault();


        public UserManagement()
        {
            _userValidator = new UserValidator();
        }

        public int GetCount() => _users.Count;
        public void AddNewUser(User user)
        {

            (bool isValid, string error) isValidation =
                _userValidator.IsValidationUserForAdd(user);

            if (!isValidation.isValid)
                throw new NotValidaUserForAddException(isValidation.error);
            _users.Add(user);
        }

        internal User? GetSingleUser(string phone)
        {
            var user = FindByPhone(phone);
            if (user == null)
                throw new NotExistUserException($"User that not exist");
            return user;
        }

        internal void DeleteUser(string phone)
        {
            var item = FindByPhone(phone);
            _users.Remove(item);
        }

        internal void UpdateUser(User user)
        {
            (bool isValid, string error) isValidation =
                _userValidator.IsValidationUserForAdd(user);

            if (!isValidation.isValid)
                throw new NotValidaUserForAddException("");

            var entity = FindByPhone(user.Phone);
            if (entity == null)
                throw new NotExistUserException("");

            entity.Name = user.Name;
        }
    }
}