using LogisticsCenter.Model;
using LogisticsCenter.Model.ProgramModels;
using LogisticsCenter.Presenters.Filling;
using System;

namespace LogisticsCenter.Presenters.Table
{
    public interface ITablePresenter
    {
        event Action<Type> FormClosed;
        void Run(User user);

        event Action<User, IModel, FillType, Type> FillingRequired;

        void ApplyFilling(FillType fillType);

        event Action<Type> RequestSearchCriteria;

        void ApplySearchCriteria(string searchBy, object searchValue);

        void EnableFormsButts();
    }
}