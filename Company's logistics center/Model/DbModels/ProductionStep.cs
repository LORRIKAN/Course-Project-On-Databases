using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsCenter.Model.DbModels
{
    [Table("Этап производства")]
    [DisplayName("Этапы производства")]
    public partial class ProductionStep : IModel
    {
        public ProductionStep()
        {
            NextSteps = new HashSet<ProductionStep>();
            Specifications = new HashSet<Specification>();
        }

        [Key]
        [Column("ID этапа")]
        [DisplayName("ID этапа")]
        [ReadOnly(true)]
        [Category("Автозаполнение")]
        public long StepID { get; set; }

        long? nextStepID;
        [Column("ID следующего этапа")]
        [DisplayName("ID следующего этапа")]
        [Category("Необязательные поля")]
        [ReadOnly(false)]
        public long? NextStepID
        {
            get => nextStepID; set
            {
                if (value == StepID) throw new Exception("ID нынешнего " +
"и следующего этапов не могут совпадать"); nextStepID = value;
            }
        }

        [Column("Описание")]
        [DisplayName("Описание")]
        [Category("Необязательные поля")]
        [ReadOnly(false)]
        public string Description { get; set; }

        [ForeignKey(nameof(NextStepID))]
        [InverseProperty(nameof(ProductionStep.NextSteps))]
        [Browsable(false)]
        public virtual ProductionStep PreviousStep { get; set; }

        [InverseProperty(nameof(ProductionStep.PreviousStep))]
        [Browsable(false)]
        public virtual ICollection<ProductionStep> NextSteps { get; set; }

        [InverseProperty(nameof(Specification.ProductionStep))]
        [Browsable(false)]
        public virtual ICollection<Specification> Specifications { get; set; }

        [Browsable(false)]
        [NotMapped]
        public string TableNameToString => ((DisplayNameAttribute)Attribute.
            GetCustomAttribute(typeof(ProductionStep), typeof(DisplayNameAttribute))).DisplayName;
    }
}