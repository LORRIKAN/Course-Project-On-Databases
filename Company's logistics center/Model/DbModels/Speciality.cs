using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsCenter.Model.DbModels
{
    [Table("Специальность")]
    [DisplayName("Специальности")]
    public partial class Speciality : IModel
    {
        public Speciality()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        [Column("Код специальности")]
        [DisplayName("Код специальности")]
        [ReadOnly(true)]
        [Category("Автозаполнение")]
        public long SpecialityID { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите наименование специальности.")]
        [Column("Наименование")]
        [DisplayName("Наименование")]
        [Category("Обязательные поля")]
        [ReadOnly(false)]
        public string Name { get; set; }

        [Column("Список прав")]
        [DisplayName("Список прав")]
        [Category("Обязательные поля")]
        [ReadOnly(false)]
        public string RightsList { get; set; }

        [Column("Описание")]
        [DisplayName("Описание")]
        [Category("Необязательные поля")]
        [ReadOnly(false)]
        public string Description { get; set; }

        [InverseProperty(nameof(Employee.Speciality))]
        [Browsable(false)]
        public virtual ICollection<Employee> Employees { get; set; }

        [Browsable(false)]
        [NotMapped]
        public string TableNameToString => ((DisplayNameAttribute)Attribute.
            GetCustomAttribute(typeof(Speciality), typeof(DisplayNameAttribute))).DisplayName;
    }
}
