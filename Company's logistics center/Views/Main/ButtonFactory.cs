using LogisticsCenter.Model;
using LogisticsCenter.Presenters.Main.EntityChoose;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LogisticsCenter.Views.Main
{
    public class ButtonFactory : IButtonFactory
    {
        public List<IButtPresenter> ButtPresenters { get; } = new List<IButtPresenter>();

        public Button GetButtonFromPresenter<T>() where T : class, IModel, new()
        {
            var presenter = new ButtPresenter<T>();

            var butt = presenter.Butt;

            ButtPresenters.Add(presenter);

            return butt;
        }
    }
}