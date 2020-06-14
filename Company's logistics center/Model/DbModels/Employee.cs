using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsCenter.Model.DbModels
{
    [Table("Сотрудник")]
    [DisplayName("Сотрудники")]
    public partial class Employee : IModel
    {
        public Employee()
        {
            TransferOrders = new HashSet<TransferOrder>();
            StationaryWarehouses = new HashSet<StationaryWarehouse>();
        }

        [Key]
        [Required(ErrorMessage = "Пожалуйста, введите логин.")]
        [Column("Логин")]
        [DisplayName("Логин")]
        [Category("Обязательные поля")]
        [ReadOnly(false)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите ID специальности.")]
        [Column("Код специальности")]
        [DisplayName("Код специальности")]
        [Category("Обязательные поля")]
        [ReadOnly(false)]
        public long SpecialityID { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите пароль.")]
        [Column("Пароль")]
        [DisplayName("Пароль")]
        [Category("Обязательные поля")]
        [ReadOnly(false)]
        public string Password { get; set; }

        [ForeignKey(nameof(SpecialityID))]
        [InverseProperty(nameof(DbModels.Speciality.Employees))]
        [Browsable(false)]
        public virtual Speciality Speciality { get; set; }

        [InverseProperty(nameof(TransferOrder.Logistician))]
        [Browsable(false)]
        public virtual ICollection<TransferOrder> TransferOrders { get; set; }

        [InverseProperty(nameof(StationaryWarehouse.Warehouseman))]
        [Browsable(false)]
        public virtual ICollection<StationaryWarehouse> StationaryWarehouses { get; set; }

        [Browsable(false)]
        [NotMapped]
        public string TableNameToString => ((DisplayNameAttribute)Attribute.
            GetCustomAttribute(typeof(Employee), typeof(DisplayNameAttribute))).DisplayName;
    }
}
