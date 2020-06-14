using LogisticsCenter.Views.Search;
using System;

namespace LogisticsCenter.Presenters.Search
{
    public interface ISearchPresenter
    {
        void Run(Type modelType);

        event ReturnSearchCriteria ReturnSearchCriteria;

        event Action PresenterClosure;
    }
}