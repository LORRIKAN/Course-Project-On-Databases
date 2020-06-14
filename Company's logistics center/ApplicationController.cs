using Autofac;
using LogisticsCenter.Model.DbModels;
using LogisticsCenter.Model.ProgramModels;
using LogisticsCenter.Presenters.Filling;
using LogisticsCenter.Presenters.Login;
using LogisticsCenter.Presenters.Main;
using LogisticsCenter.Presenters.Main.Info;
using LogisticsCenter.Presenters.Search;
using LogisticsCenter.Presenters.Table;
using LogisticsCenter.Repository;
using LogisticsCenter.Views.Login;
using LogisticsCenter.Views.MessageService;
using System;
using System.Windows.Forms;

namespace LogisticsCenter
{
    public class ApplicationController : IApplicationController
    {
        ILoginPresenter LoginFormPresenter { get; set; }

        IMessageService MessageService { get; set; }

        IMainPresenter MainFormPresenter { get; set; }

        DatabaseContext Context { get; set; }

        User User { get; set; }

        LoginAttemptResult LoginAttemptResult { get; set; }

        bool reloginAttempt = false;

        ILifetimeScope Scope { get; set; }

        public ApplicationController(ILoginPresenter loginFormPresenter, IMessageService messageService,
            DatabaseContext dbContext, IMainPresenter mainFormPresenter)
        {
            MessageService = messageService;
            Context = dbContext;

            LoginFormPresenter = loginFormPresenter;
            LoginFormPresenter.OnPresenterClosed += (Tuple<LoginAttemptResult, Employee> obj) =>
            {
                try
                {
                    LoginAttemptResult = obj.Item1;
                    if (LoginAttemptResult == LoginResults.Success)
                        User = new User(Context, obj.Item2);
                }
                catch (Exception e) { MessageService.
                    ShowError(e.Message + " Программа не может продолжать свою работу.");
                    Environment.Exit(0); }
            };

            MainFormPresenter = mainFormPresenter;
            MainFormPresenter.PresenterClosed += (reloginAttempt) => this.reloginAttempt = reloginAttempt;
            MainFormPresenter.EntityTypeReceived += (type) =>
            {
                var tablePresenter = (ITablePresenter)Scope.Resolve(type);
                tablePresenter.FormClosed += (entityType) => MainFormPresenter.EnableButtAfterFormClosure(entityType);

                tablePresenter.FillingRequired += (user, model, fillingType, presenterType) =>
                {
                    var fillingPresenter = (IFillingPresenter)Scope.Resolve(presenterType);
                    fillingPresenter.FillingCompleted += (fillType) => tablePresenter.ApplyFilling(fillingType);
                    fillingPresenter.Run(user, model, fillingType);
                    fillingPresenter.PresenterClosure += () => tablePresenter.EnableFormsButts();
                };

                tablePresenter.RequestSearchCriteria += (entityType) =>
                {
                    var searchPresenter = Scope.Resolve<ISearchPresenter>();

                    searchPresenter.ReturnSearchCriteria += (searchBy, searchValue) =>
                    tablePresenter.ApplySearchCriteria(searchBy, searchValue);
                    searchPresenter.PresenterClosure += () => tablePresenter.EnableFormsButts();

                    searchPresenter.Run(entityType);
                };

                tablePresenter.Run(User);
            };
            MainFormPresenter.InfoRequired += (infoType) => Scope.Resolve<IInfoPresenter>().Run(infoType);
        }

        public bool Run(ILifetimeScope scope)
        {
            Context.UpdateDb();
            Scope = scope;
            LoginFormPresenter.Run();
            if (LoginAttemptResult != LoginResults.Success)
                return false;
            MainFormPresenter.Run(User);
            foreach (Form form in Application.OpenForms)
                form.Close();
            return reloginAttempt;
        }
    }
}