using LogisticsCenter.Model;
using System;

namespace LogisticsCenter.Views.Filling
{
    public delegate string CheckProperty(string propertyName, object propertyValue);

    public delegate string CheckObject(IModel obj);
    public interface IFillingForm
    {
        void Show(IModel model);

        event CheckProperty CheckProperty;

        event CheckObject CheckModel;

        event Action<IModel> SuccessfullyFilled;

        event Action FormClosure;
    }
}