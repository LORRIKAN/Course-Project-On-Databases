using LogisticsCenter.Model.ProgramModels;
using LogisticsCenter.Presenters.Main.Info;
using LogisticsCenter.Repository;
using LogisticsCenter.Views.Main;
using LogisticsCenter.Views.MessageService;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LogisticsCenter.Presenters.Main
{
    public class MainPresenter : IMainPresenter
    {
        public event Action<bool> PresenterClosed;

        public event Action<Type> EntityTypeReceived;

        public event Action<InfoType> InfoRequired;

        IMainForm MainForm { get; set; }

        IMessageService MessageService { get; set; }

        User User { get; set; }

        DatabaseContext Context { get; set; }

        IButtonFactory ButtonFactory { get; set; }

        public MainPresenter(IMainForm mainForm, DatabaseContext context, IMessageService messageService)
        {
            MainForm = mainForm;
            MainForm.OnFormClosing += CloseFormOrNot;
            MainForm.SetButtsRights += SetButtsRights;
            MainForm.InfoButtClicked += (infoType) => InfoRequired.Invoke(infoType);

            Context = context;
            MessageService = messageService;
        }

        private void CloseFormOrNot(bool relogin, FormClosingEventArgs e)
        {
            if (Context.ChangeTracker.HasChanges())
                if (MessageService
                    .ShowOkCancel("Вы действительно хотите выйти? Все несохранённые изменения будут утеряны."))
                {
                    PresenterClosed.Invoke(relogin);
                    return;
                }
                else e.Cancel = true;
            else PresenterClosed.Invoke(relogin);
        }

        private void SetButtsRights(IButtonFactory buttonFactory)
        {
            ButtonFactory = buttonFactory;
            foreach (var presenter in ButtonFactory.ButtPresenters)
            {
                presenter.ButtonClicked += (type) =>
                {
                    presenter.Butt.Enabled = false;
                    EntityTypeReceived.Invoke(type);
                };
                presenter.Butt.Enabled = User.RightsForEntitiesAndFields.Any(e => e.EntityType == presenter.EntityType);
            }
        }

        public void Run(User user)
        {
            User = user;
            MainForm.Header = $"Вы вошли как {User.Login} Специальность: {User.Speciality}";
            MainForm.Show();
        }

        public void EnableButtAfterFormClosure(Type entityType)
        {
            ButtonFactory.ButtPresenters.Find(bp => bp.EntityType == entityType).Butt.Enabled = true;
        }
    }
}