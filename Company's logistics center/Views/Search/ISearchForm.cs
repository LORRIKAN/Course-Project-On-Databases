using System;

namespace LogisticsCenter.Views.Search
{
    public delegate void ReturnSearchCriteria(string searchBy, object searchValue);
    public interface ISearchForm
    {
        void Show(string[] comboBoxItems);

        void Close();

        event ReturnSearchCriteria ReturnSearchCriteria;

        event Action FormClosure;
    }
}