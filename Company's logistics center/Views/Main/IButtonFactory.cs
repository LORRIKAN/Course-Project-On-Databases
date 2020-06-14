using LogisticsCenter.Model;
using LogisticsCenter.Presenters.Main.EntityChoose;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LogisticsCenter.Views.Main
{
    public interface IButtonFactory
    {
        List<IButtPresenter> ButtPresenters { get; }

        Button GetButtonFromPresenter<T>() where T : class, IModel, new();
    }
}