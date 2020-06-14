using LogisticsCenter.Model;
using LogisticsCenter.Model.ProgramModels;
using LogisticsCenter.Presenters.Filling;
using LogisticsCenter.Repository;
using LogisticsCenter.Views.MessageService;
using LogisticsCenter.Views.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Windows.Forms;

namespace LogisticsCenter.Presenters.Table
{
    public class TablePresenter<TEntity> : ITablePresenter where TEntity : class, IModel, new()
    {
        protected string NL = Environment.NewLine;

        public event Action<Type> FormClosed;

        public event Action<User, IModel, FillType, Type> FillingRequired;

        public event Action<Type> RequestSearchCriteria;

        protected ITableForm<TEntity> TableForm { get; set; }

        protected IMessageService MessageService { get; set; }

        protected DbSet<TEntity> SetOfEntities { get; set; }

        protected User User { get; set; }

        protected List<TEntity> ListOfEntities { get; set; } = new List<TEntity>();

        protected DatabaseContext Context { get; set; }

        protected TEntity LastModifiedEntity { get; set; }

        public TablePresenter(IMessageService messageService, DatabaseContext context,
            ITableForm<TEntity> tableForm)
        {
            TableForm = tableForm;
            MessageService = messageService;
            Context = context;
            SetSetOfEntities();
            TableForm = tableForm;
        }

        protected virtual void SetSetOfEntities()
        {
            SetOfEntities = Context.Set<TEntity>();
        }

        public void Run(User user)
        {
            User = user;
            SetEvents();
            TableForm.Header = new TEntity().TableNameToString;
            TableForm.Show();
        }

        protected virtual void SetEvents()
        {
            TableForm.RequestButtsRights += RetrieveButtsRights;

            TableForm.GetSource += () =>
            {
                if (Context.CheckIfEntityHasChanges<TEntity>())
                {
                    if (MessageService.ShowOkCancel("Вы действительно хотите сбросить таблицу? Все внесённые вами " +
                        "изменения в этой и других таблицах будут утеряны."))
                        UpdateFormDataSourceFromDatabase();
                }
                else
                    UpdateFormDataSourceFromDatabase();
                EnableFormsButts();
            };

            TableForm.Save += () => { SaveChanges(); EnableFormsButts(); };

            TableForm.MakeSearch += () => RequestSearchCriteria.Invoke(typeof(TEntity));

            TableForm.GetNonSearch += () => { TableForm.DataSource = ListOfEntities; EnableFormsButts(); };

            TableForm.DeleteRecords += (records) => { DeleteRecords(records); EnableFormsButts(); };

            TableForm.FormClosing += TableForm_FormClosing;

            TableForm.AddNewRecord += () =>
            {
                LastModifiedEntity = new TEntity();
                FillingRequired.Invoke(User, LastModifiedEntity, FillType.Add, typeof(FillingPresenter<TEntity>));
            };

            TableForm.UpdateRecords += (entities) =>
            {
                LastModifiedEntity = entities.First();
                FillingRequired.Invoke(User, LastModifiedEntity, FillType.Update, typeof(FillingPresenter<TEntity>));
            };
        }

        private void TableForm_FormClosing(FormClosingEventArgs e)
        {
            if (Context.CheckIfEntityHasChanges<TEntity>())//|| List открытых форм не пустой
                if (!MessageService.ShowOkCancel("Вы действительно хотите выйти? Все несохранённые изменения " +
                    "будут утеряны, а открытые формы закрыты."))
                {
                    e.Cancel = true;
                }
            FormClosed.Invoke(typeof(TEntity));
        }

        protected virtual void RetrieveButtsRights()
        {
            var entity = User.RightsForEntitiesAndFields.Find(e => e.EntityType == typeof(TEntity));

            TableForm.AddButtEnabled = entity.AddRowsRight;
            TableForm.DeleteButtEnabled = entity.DeleteRowsRight;

            var fields = entity.Fields;
            TableForm.UpdateButtEnabled = fields.Any(f => f.Updatable);

            TableForm.SaveButtEnabled = entity.AddRowsRight || entity.DeleteRowsRight
                    || TableForm.UpdateButtEnabled;
        }

        private void UpdateFormDataSourceFromDatabase()
        {
            Context.UpdateDb();
            ListOfEntities = SetOfEntities.ToList();
            TableForm.DataSource = ListOfEntities;
            Context.ChangeTracker.AcceptAllChanges();
        }

        protected virtual void DeleteRecords(List<TEntity> itemsToDelete)
        {
            bool failedToDelete = false;
            foreach (var item in itemsToDelete)
            {
                try
                {
                    Context.Remove(item);
                    Context.TrySave();
                    ListOfEntities.Remove(item);
                }
                catch
                {
                    failedToDelete = true;
                }
            }
            TableForm.DataSource = ListOfEntities;
            if (failedToDelete) MessageService.ShowError("Не удалось удалить одну или несколько записей. " +
                "Скорее всего они учавствуют в записях других таблиц.");
        }

        private void SaveChanges()
        {
            try
            {
                if (Context.ChangeTracker.HasChanges())
                {
                    if (MessageService.ShowOkCancel("Внимание! Это действие приведёт к попытке сохранения изменений " +
                        "во всех открытых таблицах! Вы уверены, что хотите продолжить?"))
                    {
                        Context.SaveChanges();
                        UpdateFormDataSourceFromDatabase();
                        MessageService.ShowMessage("Данные успешно сохранены.");
                    }
                }
            }
            catch
            {
                MessageService.ShowError("Данные не были сохранены. Попробуйте найти и изменить неверные данные.");
            }
        }

        public void ApplySearchCriteria(string searchBy, object searchValue)
        {
            List<TEntity> filteredList = ListOfEntities.Where($"{searchBy}=@0", searchValue).ToList();

            if (filteredList != null)
                TableForm.DataSource = filteredList;
            else
                MessageService.ShowExclamation("Что-то пошло не так. Попробуйте задать другие критерии поиска.");
        }

        public void EnableFormsButts()
        {
            TableForm.EnableButts();
        }

        public void ApplyFilling(FillType fillType)
        {
            if (fillType == FillType.Add)
            {
                ListOfEntities.Add(LastModifiedEntity);
                SetOfEntities.Add(LastModifiedEntity);
            }
            else
            {
                SetOfEntities.Update(LastModifiedEntity);
            }

            TableForm.DataSource = ListOfEntities;
        }
    }
}