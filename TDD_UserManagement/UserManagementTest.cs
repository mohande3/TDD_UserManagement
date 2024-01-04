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
            var act = () => _sut.AddNewUser(new User
            {
                Phone = ""
            });

            act.Should().Throw<NotValidaUserForAddException>();
            //! .WithMessage($"{nameof(User.Name)} can not be null or empty");
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


        [Fact]
        public void When_get_single_user_that_not_exists_Expect_fier_exception()
        {
            var act = () => _sut.GetSingleUser("");

            act.Should().Throw<NotExistUserException>();
            //!  .WithMessage($"User that not exist");
        }


        [Fact]
        public void When_get_single_user_exists_Expect_get_user_success()
        {
            //! Arrange
            var userExpect = new User { Name = "ALI", Phone = "099" };

            //! Act
            _sut.AddNewUser(userExpect);
            var userResult = _sut.GetSingleUser("099");

            //! Assertion
            userResult.Should().NotBeNull();
            userResult.Phone.Should().Be(userExpect.Phone);
            userResult.Name.Should().Be(userExpect.Name);
        }


        [Fact]
        public void When_delete_exist_user_Expect_success()
        {
            //! Arrange
            var userExpect = new User { Name = "ALI", Phone = "099" };
            var countBeforeDelete = _sut.GetCount();
            _sut.AddNewUser(userExpect);

            //! Act
            _sut.DeleteUser("099");

            //! Assertion
            _sut.GetCount().Should().Be(countBeforeDelete - 1);
        }

        [Fact]
        public void When_delete_not_exist_user_Expect_success()
        {
            //! Arrange

            //! Act
            _sut.DeleteUser("099");

            //! Assertion
            _sut.GetCount().Should().Be(0);
        }

        [Fact]
        public void When_update_not_exist_user_Expect_get_exception()
        {
            //! Arrange

            //! Act
            var act = () => _sut.UpdateUser(new User { Name = "Ali", Phone = "098" });

            //! Assertion
            act.Should().Throw<NotExistUserException>();
        }

        [Fact]
        public void When_update_with_empty_phone_Expect_get_exception()
        {
            //! Arrange

            //! Act
            var act = () => _sut.UpdateUser(new User { Name = "Ali", Phone = "" });

            //! Assertion
            act.Should().Throw<NotValidaUserForAddException>();
        }

        [Fact]
        public void When_update_with_exist_user_Expect_change_it()
        {
            //! Arrange
            var user = new User { Name = "Ali", Phone = "98" };
            _sut.AddNewUser(user);

            //! Act
            var user2 = new User { Name = "VAHID", Phone = "98" };
            _sut.UpdateUser(user2);

            //! Assertion
            var newUser = _sut.GetSingleUser(user.Phone);
            newUser.Name.Should().Be(user2.Name);
        }
    }
}
