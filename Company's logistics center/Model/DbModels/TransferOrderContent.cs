using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsCenter.Model.DbModels
{
    [Table("Состав заказа")]
    [DisplayName("Составы заказов")]
    public partial class TransferOrderContent : IModel
    {
        [Key]
        [Required(ErrorMessage = "Пожалуйста, введите ID маршрута.")]
        [Column("ID заказа")]
        [DisplayName("ID заказа")]
        [Category("Обязательные поля")]
        public long TransferOrderID { get; set; }

        [Key]
        [Required(ErrorMessage = "Пожалуйста, введите ID ресурса.")]
        [Column("ID ресурса")]
        [DisplayName("ID ресурса")]
        [Category("Обязательные поля")]
        [RegularExpression("^((Т|М){1}([0-9]+))$", ErrorMessage = "Формат ID ресурса должен быть следующим: " +
            "Т - для товара, М - для материала, далеее цифры, например, Т56, М90.")]
        public string ResourceID { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите количество ресурса.")]
        [Column("Количество ресурса")]
        [DisplayName("Количество ресурса")]
        [Category("Обязательные поля")]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Слишком малое или большое значение")]
        public double ResourceAmount { get; set; }

        [ForeignKey(nameof(TransferOrderID))]
        [InverseProperty(nameof(DbModels.TransferOrder.OrderContent))]
        [Browsable(false)]
        public virtual TransferOrder TransferOrder { get; set; }

        [ForeignKey(nameof(ResourceID))]
        [InverseProperty(nameof(ProductOrMaterial.TransferOrderContents))]
        [Browsable(false)]
        public virtual ProductOrMaterial Resource { get; set; }

        [Browsable(false)]
        [NotMapped]
        public string TableNameToString => ((DisplayNameAttribute)Attribute.
            GetCustomAttribute(typeof(TransferOrderContent), typeof(DisplayNameAttribute))).DisplayName;
    }
}
