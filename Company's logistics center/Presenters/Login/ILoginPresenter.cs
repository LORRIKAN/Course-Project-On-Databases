using LogisticsCenter.Model.DbModels;
using LogisticsCenter.Views.Login;
using System;

namespace LogisticsCenter.Presenters.Login
{
    public interface ILoginPresenter
    {
        void Run();

        event Action<Tuple<LoginAttemptResult, Employee>> OnPresenterClosed;
    }
}