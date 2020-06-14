using LogisticsCenter.Model.ProgramModels;
using LogisticsCenter.Presenters.Main.Info;
using System;

namespace LogisticsCenter.Presenters.Main
{
    public interface IMainPresenter
    {
        void Run(User user);

        event Action<bool> PresenterClosed;

        event Action<Type> EntityTypeReceived;

        event Action<InfoType> InfoRequired;

        void EnableButtAfterFormClosure(Type entityType);
    }
}