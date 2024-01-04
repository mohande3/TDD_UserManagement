using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_UserManagement
{
    //todo TDD : TEST-> SOME CODE -> REFACTOR ....
    public class UserManagementTest
    {

        UserManagement _sut;

        public UserManagementTest()
        {
            _sut = new UserManagement();
        }

        [Fact]
        public void When_create_instance_from_UserManagement_Expect_ok()
        {
            _sut.Should().NotBeNull();
        }

        [Fact]
        public void When_add_new_user_with_empty_name_Expect_get_error()
        {
         var act = ()=>   _sut.AddNewUser(new User
            {
                Phone = ""
            });

            act.Should().Throw<Exception>()
                .WithMessage($"{nameof(User.Name)} can not be null or empty");
        }

        [Fact]
        public void When_add_new_user_with_empty_phone_Expect_get_error()
        {
            var act = () => _sut.AddNewUser(new User
            {
                Name = "ali"
            });

            act.Should().Throw<Exception>()
                .WithMessage($"{nameof(User.Phone)} can not be null or empty");
        }
    }
}
