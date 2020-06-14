namespace LogisticsCenter.Views.Login
{

    public delegate LoginAttemptResult LoginAttempt(string login, string password);

    public delegate void FormClosed(LoginAttemptResult loginAttemptResult);
    public interface ILoginForm
    {
        void Show();

        event LoginAttempt OnLoginAttempt;

        event FormClosed OnFormClosed;
    }
}