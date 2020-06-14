using LogisticsCenter.Views.MessageService;
using LogisticsCenter.Views.Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace LogisticsCenter.Presenters.Search
{
    public class SearchPresenter : ISearchPresenter
    {
        ISearchForm SearchForm { get; set; }

        IMessageService MessageService { get; set; }

        Dictionary<string, string> ProgramAndUserPropsNames = new Dictionary<string, string>();

        Dictionary<string, Type> PropsTypes = new Dictionary<string, Type>();

        public SearchPresenter(ISearchForm searchForm, IMessageService messageService)
        {
            MessageService = messageService;

            SearchForm = searchForm;
            SearchForm.ReturnSearchCriteria += CheckAndReturnSearchCriteria;

            SearchForm.FormClosure += () => PresenterClosure.Invoke();
        }

        private void CheckAndReturnSearchCriteria(string searchBy, object searchValue)
        {
            var propProgramName = ProgramAndUserPropsNames[searchBy];
            var propType = PropsTypes[searchBy];
            try
            {
                var value = Convert.ChangeType(searchValue, propType);
                ReturnSearchCriteria.Invoke(propProgramName, value);
                SearchForm.Close();
            }
            catch
            {
                MessageService.ShowError("Неверный формат! Попробуйте ввести другое значение.");
            }
        }

        public event ReturnSearchCriteria ReturnSearchCriteria;

        public event Action PresenterClosure;

        public void Run(Type modelType)
        {
            var props = modelType.GetProperties();
            var propsNames = new List<string>();

            foreach (var prop in props)
            {
                var programName = prop.Name;

                var userName = prop.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;

                var type = prop.PropertyType;

                if (userName != null)
                {
                    propsNames.Add(userName);
                    ProgramAndUserPropsNames.Add(userName, programName);
                    PropsTypes.Add(userName, type);
                }
            }

            SearchForm.Show(propsNames.ToArray());
        }
    }
}