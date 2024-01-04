
namespace TDD_UserManagement
{
    internal class UserManagement
    {

        internal static List<User> _users = new List<User>();

        public UserManagement()
        {
        }

        public int GetCount() => _users.Count;
        public void AddNewUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
                throw new Exception($"{nameof(User.Name)} can not be null or empty");
            if (string.IsNullOrWhiteSpace(user.Phone))
                throw new Exception($"{nameof(User.Phone)} can not be null or empty");
            _users.Add(user);
        }
    }
}