using APISendIt;

namespace unit_test_User
{
    [TestClass]
    public class SignUpTest
    {
        [TestMethod]
        public void SignUpUser_Success()
        {
            // Test case: User sign up succeeds
            SignUpUser signUpUser = new SignUpUser();
            string username = "User_user";
            string password = "User_password";
            string email = "User@example.com";
            bool signUpResult = signUpUser.SignUp(username, password, email);
            Assert.IsTrue(signUpResult);
        }

        [TestMethod]
        public void SignUpUser_Failure()
        {
            // Test case: User sign up fails (e.g., duplicate username)
            SignUpUser signUpUser = new SignUpUser();
            string username = "existing_user";
            string password = "User_password";
            string email = "User@example.com";
            bool signUpResult = signUpUser.SignUp(username, password, email);
            Assert.IsFalse(signUpResult);
        }
    }
}

