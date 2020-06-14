using LogisticsCenter.Model;
using LogisticsCenter.Model.ProgramModels;
using System;

namespace LogisticsCenter.Presenters.Filling
{
    public interface IFillingPresenter
    {
        void Run(User user, IModel model, FillType fillingType);

        event Action<FillType> FillingCompleted;

        event Action PresenterClosure;
    }
}