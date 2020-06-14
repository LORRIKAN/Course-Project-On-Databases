using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsCenter.Model.DbModels
{
    [Table("Маршрут перемещения")]
    [DisplayName("Маршруты перемещения")]
    public partial class TransferRoute : IModel
    {
        public TransferRoute()
        {
            TransferOrders = new HashSet<TransferOrder>();
        }

        [Key]
        [Column("ID маршрута")]
        [DisplayName("ID маршрута")]
        [ReadOnly(true)]
        [Category("Автозаполнение")]
        public long RouteID { get; set; }

        string initialWarehouseID;
        [Required(ErrorMessage = "Пожалуйста, введите ID начального склада.")]
        [Column("ID начального склада")]
        [DisplayName("ID начального склада")]
        [Category("Обязательные поля")]
        [ReadOnly(false)]
        [RegularExpression("^((С|З|(ПМ)|(ПЦ)){1}([0-9])+)$", ErrorMessage = "Формат ID склада должен быть следующим: " +
            "С - для стационарного склада, З - для склада заказчика, ПМ - для поставщика материала, ПЦ - " +
            "для производственного цеха, например, С46, З90, ПМ67, ПЦ1.")]
        public string InitialWarehouseID
        {
            get => initialWarehouseID; set
            {
                if (value != default)
                    if (value == FinalWarehouseID)
                        throw new Exception("ID начального и конечного складов не должны совпадать.");
                initialWarehouseID = value;
            }
        }

        [Required(ErrorMessage = "Пожалуйста, введите ID транзитного склада.")]
        [Column("ID транзитного склада")]
        [DisplayName("ID транзитного склада")]
        [Category("Обязательные поля")]
        [ReadOnly(false)]
        public long TransitWarehouseID { get; set; }

        string finalWarehouseID;
        [Required(ErrorMessage = "Пожалуйста, введите ID конечного склада.")]
        [Column("ID конечного склада")]
        [DisplayName("ID конечного склада")]
        [Category("Обязательные поля")]
        [ReadOnly(false)]
        [RegularExpression("^((С|З|(ПМ)|(ПЦ)){1}([0-9])+)$", ErrorMessage = "Формат ID склада должен быть следующим: " +
            "С - для стационарного склада, З - для склада заказчика, ПМ - для поставщика материала, ПЦ - " +
            "для производственного цеха, например, С46, З90, ПМ67, ПЦ1.")]
        public string FinalWarehouseID
        {
            get => finalWarehouseID;
            set
            {
                if (value != default)
                    if (value == InitialWarehouseID)
                        throw new Exception("ID начального и конечного складов не должны совпадать.");
                finalWarehouseID = value;
            }
        }

        [Required(ErrorMessage = "Пожалуйста, введите длительность транспортировки.")]
        [Column("Длительность транспортировки")]
        [DisplayName("Длительность транспортировки")]
        [Category("Обязательные поля")]
        [ReadOnly(false)]
        public TimeSpan TransferDuration { get; set; }

        [Column("Описание")]
        [DisplayName("Описание")]
        [Category("Необязательные поля")]
        public string Description { get; set; }

        [ForeignKey(nameof(FinalWarehouseID))]
        [InverseProperty(nameof(StationaryWarehouse.TransferRoutesAsFinal))]
        [Browsable(false)]
        public virtual StationaryWarehouse FinalWarehouse { get; set; }

        [ForeignKey(nameof(InitialWarehouseID))]
        [InverseProperty(nameof(StationaryWarehouse.TransferRoutesAsInitial))]
        [Browsable(false)]
        public virtual StationaryWarehouse InitialWarehouse { get; set; }

        [ForeignKey(nameof(TransitWarehouseID))]
        [InverseProperty(nameof(DbModels.TransitWarehouse.TransferRoutes))]
        [Browsable(false)]
        public virtual TransitWarehouse TransitWarehouse { get; set; }

        [InverseProperty(nameof(TransferOrder.TransferRoute))]
        [Browsable(false)]
        public virtual ICollection<TransferOrder> TransferOrders { get; set; }

        [Browsable(false)]
        [NotMapped]
        public string TableNameToString => ((DisplayNameAttribute)Attribute.
            GetCustomAttribute(typeof(TransferRoute), typeof(DisplayNameAttribute))).DisplayName;
    }

    public class InitialAndFinalWarehousesMatchException : Exception
    {
        public new string Message => "ID начального и конечного складов не могут совпадать!";
    }

    public class TransitWarehouseBusy : Exception
    {
        public new string Message => "Склад уже занят другим заказом";
    }

    public static class TransferRouteCheck
    {
        public static void Check(this TransferRoute transferRoute)
        {
            if (transferRoute.InitialWarehouseID == transferRoute.FinalWarehouseID)
                throw new InitialAndFinalWarehousesMatchException();
        }
    }
}
