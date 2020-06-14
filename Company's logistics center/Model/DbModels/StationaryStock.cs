using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsCenter.Model.DbModels
{
    [Table("Стационарный запас")]
    [DisplayName("Стационарные запасы")]
    public partial class StationaryStock : IModel
    {
        [Key]
        [Required(ErrorMessage = "Пожалуйста, введите ID стационарного склада.")]
        [Column("ID склада")]
        [DisplayName("ID склада")]
        [Category("Обязательные поля")]
        [ReadOnly(false)]
        [RegularExpression("^((С){1}([0-9])+)$", ErrorMessage = "Только стационарный склад может иметь запасы. " +
            "Его ID начинается с \"С\"")]
        public string WarehouseID { get; set; }

        [Key]
        [Required(ErrorMessage = "Пожалуйста, введите ID ресурса.")]
        [Column("ID ресурса")]
        [DisplayName("ID ресурса")]
        [Category("Обязательные поля")]
        [ReadOnly(false)]
        [RegularExpression("^((Т|М){1}([0-9]+))$", ErrorMessage = "Формат ID ресурса должен быть следующим: " +
            "Т - для товара, М - для материала, далеее цифры, например, Т56, М90.")]
        public string ResourceID { get; set; }

        [Column("Количество ресурса")]
        [DisplayName("Количество ресурса")]
        [Category("Автозаполнение")]
        [ReadOnly(true)]
        public double ResourceAmount { get; set; } = 0;

        [ForeignKey(nameof(ResourceID))]
        [InverseProperty(nameof(ProductOrMaterial.StationaryStocks))]
        [Browsable(false)]
        public virtual ProductOrMaterial Resource { get; set; }

        [ForeignKey(nameof(WarehouseID))]
        [InverseProperty(nameof(StationaryWarehouse.StationaryStocks))]
        [Browsable(false)]
        public virtual StationaryWarehouse Warehouse { get; set; }

        [Browsable(false)]
        [NotMapped]
        public string TableNameToString => ((DisplayNameAttribute)Attribute.
            GetCustomAttribute(typeof(StationaryStock), typeof(DisplayNameAttribute))).DisplayName;
    }
}