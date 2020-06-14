using LogisticsCenter.Model.DbModels;
using LogisticsCenter.Repository;
using LogisticsCenter.Views.Login;
using System;
using System.Linq;

namespace LogisticsCenter.Presenters.Login
{
    public class LoginPresenter : ILoginPresenter
    {
        private Employee Employee { get; set; }

        ILoginForm LoginForm { get; set; }

        DatabaseContext DbContext { get; set; }

        public event Action<Tuple<LoginAttemptResult, Employee>> OnPresenterClosed;

        public LoginPresenter(ILoginForm loginForm, DatabaseContext repository)
        {
            LoginForm = loginForm;
            LoginForm.OnLoginAttempt += CheckLoginInDb;
            LoginForm.OnFormClosed += ClosePresenter;

            DbContext = repository;
        }

        private LoginAttemptResult CheckLoginInDb(string login, string password)
        {
            var loginResult = new LoginAttemptResult();

            var foundLogin = (from e in DbContext.Employees
                              where e.Login == login
                              select e.Login).SingleOrDefault();

            loginResult.LoginCorrect = foundLogin != null;
            if (loginResult == LoginResults.failedWrongLogin)
                return loginResult;

            var foundEmployee = (from e in DbContext.Employees
                                 where e.Login == login && e.Password == password
                                 select e).SingleOrDefault();

            loginResult.PasswordCorrect = foundEmployee != null;
            if (loginResult == LoginResults.Success)
                Employee = foundEmployee;

            return loginResult;
        }

        private void ClosePresenter(LoginAttemptResult loginAttemptResult)
        {
            OnPresenterClosed?.Invoke(new Tuple<LoginAttemptResult, Employee>(loginAttemptResult, Employee));
        }

        public void Run()
        {
            LoginForm.Show();
        }
    }
}