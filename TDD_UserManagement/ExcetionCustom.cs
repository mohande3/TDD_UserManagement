using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_UserManagement
{
    internal class NotValidaUserForAddException : Exception
    {
        public NotValidaUserForAddException(string message) : base(message)
        {

        }
    }


    internal class NotExistUserException : Exception
    {
        public NotExistUserException(string message) : base(message)
        {

        }
    }
}
