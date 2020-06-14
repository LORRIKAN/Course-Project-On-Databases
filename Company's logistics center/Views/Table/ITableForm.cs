using LogisticsCenter.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LogisticsCenter.Views.Table
{
    public interface ITableForm<TEntity> where TEntity : class, IModel
    {
        string Header { get; set; }

        List<TEntity> DataSource { get; set; }

        bool AddButtEnabled { get; set; }

        bool UpdateButtEnabled { get; set; }

        bool DeleteButtEnabled { get; set; }

        bool SaveButtEnabled { get; set; }

        event Action RequestButtsRights;

        event Action GetSource;

        event Action MakeSearch;

        event Action GetNonSearch;

        event Action AddNewRecord;

        event Action<List<TEntity>> UpdateRecords;

        event Action<List<TEntity>> DeleteRecords;

        event Action Save;

        event Action<FormClosingEventArgs> FormClosing;

        void Show();

        void EnableButts();
    }
}