using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsCenter.Model.DbModels
{
    [Table("Заказ перемещения")]
    [DisplayName("Заказы перемещения")]
    public partial class TransferOrder : IModel
    {
        [Browsable(false)]
        public event Func<long, TimeSpan> ReceiveDurationFromRoute;
        public TransferOrder()
        {
            OrderContent = new HashSet<TransferOrderContent>();
        }

        [Key]
        [Column("ID заказа")]
        [DisplayName("ID заказа")]
        [ReadOnly(true)]
        [Category("Автозаполнение")]
        public long OrderID { get; set; }

        [Required]
        [Column("Логин логиста")]
        [DisplayName("Логин логиста")]
        [ReadOnly(true)]
        [Category("Автозаполнение")]
        public string LogisticianLogin { get; set; }

        long transferRouteID;
        [Required(ErrorMessage = "Пожалуйста, введите ID маршрута.")]
        [Column("ID маршрута")]
        [DisplayName("ID маршрута")]
        [Category("Обязательные поля")]
        public long TransferRouteID
        {
            get => transferRouteID;
            set
            {
                transferRouteID = value;
                if (SendingDate != default)
                {
                    if (ReceiveDurationFromRoute.Invoke(TransferRouteID) != default)
                    {
                        var duration = ReceiveDurationFromRoute.Invoke(TransferRouteID);
                        ReceivingDate = SendingDate + duration;
                    }
                    else
                    {
                        throw new Exception("Такого маршрута перемещения нет.");
                    }
                }
            }
        }

        [Required]
        [Column("Статус")]
        [DisplayName("Статус")]
        [ReadOnly(true)]
        [Category("Автозаполнение")]
        public string Status { get; set; } = OrderStatuses.AwaitingSendingDate;

        DateTime sendingDate;
        [Required(ErrorMessage = "Пожалуйста, введите дату отправки.")]
        [Column("Дата отгрузки")]
        [DisplayName("Дата отгрузки")]
        [Category("Обязательные поля")]
        public DateTime SendingDate
        {
            get => sendingDate;
            set
            {
                if (value < OrderCreationDate)
                    throw new Exception("Дата создания заказа не может быть раньше, чем сегодня.");
                sendingDate = value;
                if (TransferRouteID != default)
                {
                    var duration = ReceiveDurationFromRoute.Invoke(TransferRouteID);
                    ReceivingDate = SendingDate + duration;
                }
            }
        }

        [Required]
        [Column("Дата приёма")]
        [DisplayName("Дата приёма")]
        [Category("Автозаполнение")]
        [ReadOnly(true)]
        public DateTime ReceivingDate { get; set; }

        [Required]
        [Column("Дата создания заказа")]
        [DisplayName("Дата создания заказа")]
        [ReadOnly(true)]
        [Category("Автозаполнение")]
        public DateTime OrderCreationDate { get; set; } = DateTime.Now;

        [Column("Примечание")]
        [DisplayName("Примечание")]
        [Category("Необязательные поля")]
        public string Notice { get; set; }

        [ForeignKey(nameof(TransferRouteID))]
        [InverseProperty(nameof(DbModels.TransferRoute.TransferOrders))]
        [Browsable(false)]
        public virtual TransferRoute TransferRoute { get; set; }

        [ForeignKey(nameof(LogisticianLogin))]
        [InverseProperty(nameof(Employee.TransferOrders))]
        [Browsable(false)]
        public virtual Employee Logistician { get; set; }

        [InverseProperty(nameof(TransferOrderContent.TransferOrder))]
        [Browsable(false)]
        public virtual ICollection<TransferOrderContent> OrderContent { get; set; }

        [Browsable(false)]
        public string TableNameToString => ((DisplayNameAttribute)Attribute.
            GetCustomAttribute(typeof(TransferOrder), typeof(DisplayNameAttribute))).DisplayName;
    }

    public static class OrderStatuses
    {
        public static string AwaitingSendingDate => "Ждёт дату отгрузки";

        public static string AwaitingToBeSent => "Ждёт отгрузку";

        public static string InTransit => "В пути";

        public static string AwaitingToBeReceived => "Ждёт приёма";

        public static string Closed => "Закрыт";

        public static string Outdated => "Просрочен";
    }

}