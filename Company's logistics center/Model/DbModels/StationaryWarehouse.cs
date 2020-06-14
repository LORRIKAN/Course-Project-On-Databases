using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsCenter.Model.DbModels
{
    [Table("Стационарный склад")]
    [DisplayName("Стационарные склады")]
    public partial class StationaryWarehouse : IModel
    {
        public StationaryWarehouse()
        {
            TransferRoutesAsFinal = new HashSet<TransferRoute>();
            TransferRoutesAsInitial = new HashSet<TransferRoute>();
            StationaryStocks = new HashSet<StationaryStock>();
        }

        [Key]
        [Required(ErrorMessage = "Пожалуйста, введите ID стационарного склада.")]
        [Column("ID склада")]
        [DisplayName("ID склада")]
        [Category("Обязательные поля")]
        [ReadOnly(false)]
        [RegularExpression("^((С|З|(ПМ)|(ПЦ)){1}([0-9])+)$", ErrorMessage = "Формат ID склада должен быть следующим: " +
            "С - для стационарного склада, З - для склада заказчика, ПМ - для поставщика материала, ПЦ - " +
            "для производственного цеха, например, С46, З90, ПМ67, ПЦ1.")]
        public string WarehouseID { get; set; }

        [Column("Логин кладовщика")]
        [DisplayName("Логин кладовщика")]
        [Category("Необязательные поля")]
        [ReadOnly(false)]
        public string WarehousemanID { get; set; }

        [Column("Описание")]
        [DisplayName("Описание")]
        [Category("Необязательные поля")]
        [ReadOnly(false)]
        public string Description { get; set; }

        [ForeignKey(nameof(WarehousemanID))]
        [InverseProperty(nameof(Employee.StationaryWarehouses))]
        [Browsable(false)]
        public virtual Employee Warehouseman { get; set; }

        [InverseProperty(nameof(TransferRoute.FinalWarehouse))]
        [Browsable(false)]
        public virtual ICollection<TransferRoute> TransferRoutesAsFinal { get; set; }

        [InverseProperty(nameof(TransferRoute.InitialWarehouse))]
        [Browsable(false)]
        public virtual ICollection<TransferRoute> TransferRoutesAsInitial { get; set; }

        [InverseProperty(nameof(StationaryStock.Warehouse))]
        [Browsable(false)]
        public virtual ICollection<StationaryStock> StationaryStocks { get; set; }

        [Browsable(false)]
        [NotMapped]
        public string TableNameToString => ((DisplayNameAttribute)Attribute.
            GetCustomAttribute(typeof(StationaryWarehouse), typeof(DisplayNameAttribute))).DisplayName;
    }
}