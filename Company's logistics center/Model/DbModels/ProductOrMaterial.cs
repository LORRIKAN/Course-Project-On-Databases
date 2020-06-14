using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsCenter.Model.DbModels
{
    [Table("Товар/материал")]
    [DisplayName("Товары и материалы")]
    public partial class ProductOrMaterial : IModel
    {
        public ProductOrMaterial()
        {
            TransferOrderContents = new HashSet<TransferOrderContent>();
            Specifications = new HashSet<Specification>();
            StationaryStocks = new HashSet<StationaryStock>();
        }

        [Key]
        [Required(ErrorMessage = "Пожалуйста, введите ID ресурса.")]
        [Column("ID ресурса")]
        [DisplayName("ID ресурса")]
        [Category("Обязательные поля")]
        [ReadOnly(false)]
        [RegularExpression("^((Т|М){1}([0-9]+))$", ErrorMessage = "Формат ID ресурса должен быть следующим: " +
            "Т - для товара, М - для материала, далеее цифры, например, Т56, М90.")]
        public string ResourceID { get; set; }

        [Column("Описание")]
        [DisplayName("Описание")]
        [Category("Необязательные поля")]
        [ReadOnly(false)]
        public string Description { get; set; }

        [InverseProperty(nameof(TransferOrderContent.Resource))]
        [Browsable(false)]
        public virtual ICollection<TransferOrderContent> TransferOrderContents { get; set; }

        [InverseProperty(nameof(Specification.Resource))]
        [Browsable(false)]
        public virtual ICollection<Specification> Specifications { get; set; }

        [InverseProperty(nameof(StationaryStock.Resource))]
        [Browsable(false)]
        public virtual ICollection<StationaryStock> StationaryStocks { get; set; }

        [Browsable(false)]
        [NotMapped]
        public string TableNameToString => ((DisplayNameAttribute)Attribute.
            GetCustomAttribute(typeof(ProductOrMaterial), typeof(DisplayNameAttribute))).DisplayName;
    }
}
