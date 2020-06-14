using Autofac;
using LogisticsCenter.Model.DbModels;
using LogisticsCenter.Presenters;
using LogisticsCenter.Presenters.Filling;
using LogisticsCenter.Presenters.Login;
using LogisticsCenter.Presenters.Main;
using LogisticsCenter.Presenters.Main.Info;
using LogisticsCenter.Presenters.Search;
using LogisticsCenter.Presenters.Table;
using LogisticsCenter.Repository;
using LogisticsCenter.Views.Filling;
using LogisticsCenter.Views.Login;
using LogisticsCenter.Views.Main;
using LogisticsCenter.Views.Main.Info;
using LogisticsCenter.Views.MessageService;
using LogisticsCenter.Views.Search;
using LogisticsCenter.Views.Table;

namespace LogisticsCenter
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<RepositoryHandler>().AsSelf();
            builder.RegisterType<DatabaseContext>().AsSelf();

            builder.RegisterType<WinFormsMessageService>().As<IMessageService>();

            builder.RegisterType<LoginForm>().As<ILoginForm>();
            builder.RegisterType<LoginPresenter>().As<ILoginPresenter>();

            builder.RegisterType<ButtonFactory>().As<IButtonFactory>();
            builder.RegisterType<MainForm>().As<IMainForm>();
            builder.RegisterType<MainPresenter>().As<IMainPresenter>();

            builder.RegisterType<DatesAndWarehouseChooseForm>().As<IDatesAndWarehouseChooseForm>();
            builder.RegisterType<ShowingForm>().As<IShowingForm>();
            builder.RegisterType<InfoPresenter>().As<IInfoPresenter>();

            builder.RegisterType<TableForm<Employee>>().As<ITableForm<Employee>>();
            builder.RegisterType<TableForm<ProductionStep>>().As<ITableForm<ProductionStep>>();
            builder.RegisterType<TableForm<ProductOrMaterial>>().As<ITableForm<ProductOrMaterial>>();
            builder.RegisterType<TableForm<StationaryStock>>().As<ITableForm<StationaryStock>>();
            builder.RegisterType<TableForm<TransferOrderContent>>().As<ITableForm<TransferOrderContent>>();
            builder.RegisterType<TableForm<Speciality>>().As<ITableForm<Speciality>>();
            builder.RegisterType<TableForm<Specification>>().As<ITableForm<Specification>>();
            builder.RegisterType<TableForm<StationaryWarehouse>>().As<ITableForm<StationaryWarehouse>>();
            builder.RegisterType<TableForm<TransferRoute>>().As<ITableForm<TransferRoute>>();
            builder.RegisterType<TableForm<TransitWarehouse>>().As<ITableForm<TransitWarehouse>>();

            builder.RegisterType<TransferOrdersTableForm>().As<ITransferOrdersTableForm>();

            builder.RegisterType<TablePresenter<Employee>>().AsSelf();
            builder.RegisterType<TablePresenter<ProductionStep>>().AsSelf();
            builder.RegisterType<TablePresenter<ProductOrMaterial>>().AsSelf();
            builder.RegisterType<TablePresenter<Speciality>>().AsSelf();
            builder.RegisterType<TablePresenter<Specification>>().AsSelf();
            builder.RegisterType<TablePresenter<StationaryWarehouse>>().AsSelf();
            builder.RegisterType<TablePresenter<TransferRoute>>().AsSelf();
            builder.RegisterType<TablePresenter<TransitWarehouse>>().AsSelf();

            builder.RegisterType<StationaryStocksTablePresenter>().As<TablePresenter<StationaryStock>>();
            builder.RegisterType<TransferOrdersTablePresenter>().As<TablePresenter<TransferOrder>>();
            builder.RegisterType<TransferOrdersContentTablePresenter>().As<TablePresenter<TransferOrderContent>>();

            builder.RegisterType<FillingForm>().As<IFillingForm>();

            builder.RegisterType<FillingPresenter<Employee>>().AsSelf();
            builder.RegisterType<FillingPresenter<ProductionStep>>().AsSelf();
            builder.RegisterType<FillingPresenter<ProductOrMaterial>>().AsSelf();
            builder.RegisterType<FillingPresenter<Speciality>>().AsSelf();
            builder.RegisterType<FillingPresenter<Specification>>().AsSelf();
            builder.RegisterType<FillingPresenter<StationaryWarehouse>>().AsSelf();
            builder.RegisterType<FillingPresenter<StationaryStock>>().AsSelf();
            builder.RegisterType<FillingPresenter<TransferRoute>>().AsSelf();
            builder.RegisterType<FillingPresenter<TransitWarehouse>>().AsSelf();

            builder.RegisterType<FillingTransferOrderPresenter>().As<FillingPresenter<TransferOrder>>();
            builder.RegisterType<FillingTransferOrderContentPresenter>().As<FillingPresenter<TransferOrderContent>>();

            builder.RegisterType<SearchForm>().As<ISearchForm>();
            builder.RegisterType<SearchPresenter>().As<ISearchPresenter>();

            builder.RegisterType<ApplicationController>().As<IApplicationController>();

            return builder.Build();
        }
    }
}