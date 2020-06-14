using LogisticsCenter.Model;
using LogisticsCenter.Model.DbModels;
using LogisticsCenter.Model.ProgramModels;
using LogisticsCenter.Repository;
using LogisticsCenter.Views.Filling;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LogisticsCenter.Presenters.Filling
{
    public class FillingTransferOrderPresenter : FillingPresenter<TransferOrder>
    {
        public FillingTransferOrderPresenter(DatabaseContext context, IFillingForm fillingForm) :
            base(context, fillingForm)
        {
        }

        public override void Run(User user, IModel order, FillType fillType)
        {
            base.Run(user, order, fillType);
            (ModelClone as TransferOrder).LogisticianLogin = user.Login;
            (ModelClone as TransferOrder).ReceiveDurationFromRoute += TransferOrder_ReceiveDurationFromRoute;
        }

        private TimeSpan TransferOrder_ReceiveDurationFromRoute(long routeID)
        {
            TransferRoute route;
            try
            {
                route = Context.TransferRoutes.AsNoTracking().SingleOrDefault(tr => tr.RouteID == routeID);
            }
            catch
            {
                throw new Exception("Такого маршрута перемещения не существует.");
            }
            return route.TransferDuration;
        }
    }
}