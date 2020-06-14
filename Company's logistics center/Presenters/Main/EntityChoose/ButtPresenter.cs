using LogisticsCenter.Model;
using LogisticsCenter.Presenters.Table;
using System;
using System.Windows.Forms;

namespace LogisticsCenter.Presenters.Main.EntityChoose
{
    public class ButtPresenter<TEntity> : IButtPresenter where TEntity : class, IModel, new()
    {
        public Button Butt { get; private set; }

        public event Action<Type> ButtonClicked;

        public Type EntityType { get; set; } = typeof(TEntity);

        public ButtPresenter()
        {
            Butt = new Button();

            Butt.Click += (sender, e) => ButtonClicked.Invoke(typeof(TablePresenter<TEntity>));
        }
    }
}