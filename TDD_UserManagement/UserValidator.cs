using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_UserManagement
{
    internal class UserValidator
    {
        internal (bool, string) IsValidationUserForAdd(User user)
        {

            if (string.IsNullOrWhiteSpace(user.Name))
                return (false, $"{nameof(User.Name)} can not be null or empty");
            if (string.IsNullOrWhiteSpace(user.Phone))
                return (false, $"{nameof(User.Phone)} can not be null or empty");

            return (true, "");
        }
    }
}
