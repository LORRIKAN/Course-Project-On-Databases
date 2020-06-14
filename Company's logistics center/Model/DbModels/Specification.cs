using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsCenter.Model.DbModels
{
    [Table("Спецификация")]
    [DisplayName("Спецификации")]
    public partial class Specification : IModel
    {
        [Key]
        [Required(ErrorMessage = "Пожалуйста, введите ID этапа производства.")]
        [Column("ID этапа")]
        [DisplayName("ID этапа")]
        [Category("Обязательные поля")]
        [ReadOnly(false)]
        public long ProductionStepID { get; set; }

        [Key]
        [Required(ErrorMessage = "Пожалуйста, введите ID входного/выходного ресурса.")]
        [Column("ID входного/выходного ресурса")]
        [DisplayName("ID входного/выходного ресурса")]
        [Category("Обязательные поля")]
        [ReadOnly(false)]
        [RegularExpression("^((Т|М){1}([0-9]+))$", ErrorMessage = "Формат ID ресурса должен быть следующим: " +
            "Т - для товара, М - для материала, далеее цифры, например, Т56, М90.")]
        public string OutputOrInputResourceID { get; set; }

        [Required(ErrorMessage = "Пожалуйста, количество входного/выходного ресурса.")]
        [Column("Количество входного/выходного ресурса")]
        [DisplayName("Количество входного/выходного ресурса")]
        [Category("Обязательные поля")]
        [ReadOnly(false)]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Слишком малое или большое значение")]
        public double OutputOrInputResourceAmount { get; set; }

        [ForeignKey(nameof(OutputOrInputResourceID))]
        [InverseProperty(nameof(ProductOrMaterial.Specifications))]
        [Browsable(false)]
        public virtual ProductOrMaterial Resource { get; set; }

        [ForeignKey(nameof(ProductionStepID))]
        [InverseProperty(nameof(DbModels.ProductionStep.Specifications))]
        [Browsable(false)]
        public virtual ProductionStep ProductionStep { get; set; }

        [Browsable(false)]
        [NotMapped]
        public string TableNameToString => ((DisplayNameAttribute)Attribute.
            GetCustomAttribute(typeof(Specification), typeof(DisplayNameAttribute))).DisplayName;
    }
}