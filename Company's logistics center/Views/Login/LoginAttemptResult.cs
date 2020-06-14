namespace LogisticsCenter.Views.Login
{
    public enum LoginResults
    {
        Success,
        failedNoAttemt,
        failedWrongLogin,
        failedWrongPassword
    }

    public class LoginAttemptResult
    {

        private bool loginCorrect;

        private bool passwordCorrect;

        private bool attemptMade;

        public bool LoginCorrect { get => loginCorrect; set { attemptMade = true; loginCorrect = value; } }

        public bool PasswordCorrect { get => passwordCorrect; set { attemptMade = true; passwordCorrect = value; } }

        public static implicit operator LoginResults(LoginAttemptResult result)
        {
            if (!result.attemptMade)
                return LoginResults.failedNoAttemt;

            else if (!result.LoginCorrect)
                return LoginResults.failedWrongLogin;

            else if (!result.PasswordCorrect)
                return LoginResults.failedWrongPassword;

            return LoginResults.Success;
        }
    }
}