using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsCenter.Model.DbModels
{
    [Table("Транзитный склад")]
    [DisplayName("Транзитные склады")]
    public partial class TransitWarehouse : IModel
    {
        public TransitWarehouse()
        {
            TransferRoutes = new HashSet<TransferRoute>();
        }

        [Key]
        [Column("ID склада")]
        [DisplayName("ID склада")]
        [ReadOnly(true)]
        [Category("Автозаполнение")]
        public long WarehouseID { get; set; }

        [Required]
        [Column("Статус")]
        [DisplayName("Статус")]
        [ReadOnly(true)]
        [Category("Автозаполнение")]
        [DefaultValue("Не занят")]
        public string Status { get; set; } = TransitWarehouseStatuses.NotBusy;

        [Column("Описание")]
        [DisplayName("Описание")]
        [Category("Необязательные поля")]
        [ReadOnly(false)]
        public string Description { get; set; }

        [InverseProperty(nameof(TransferRoute.TransitWarehouse))]
        [Browsable(false)]
        public virtual ICollection<TransferRoute> TransferRoutes { get; set; }

        [Browsable(false)]
        [NotMapped]
        public string TableNameToString => ((DisplayNameAttribute)Attribute.
            GetCustomAttribute(typeof(TransitWarehouse), typeof(DisplayNameAttribute))).DisplayName;
    }

    public static class TransitWarehouseStatuses
    {
        public static string NotBusy => "Не занят";

        public static string Busy => "Занят";
    }
}