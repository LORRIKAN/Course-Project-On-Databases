using System.ComponentModel;

namespace LogisticsCenter.Model
{
    public interface IModel
    {
        [Browsable(false)]
        string TableNameToString { get; }
    }
}