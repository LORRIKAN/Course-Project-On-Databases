using System;
using System.Windows.Forms;

namespace LogisticsCenter.Presenters.Main.EntityChoose
{
    public interface IButtPresenter
    {
        Button Butt { get; }

        Type EntityType { get; }

        event Action<Type> ButtonClicked;
    }
}