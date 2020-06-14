using LogisticsCenter.Model.DbModels;
using LogisticsCenter.Repository;
using System;
using System.Collections.Generic;

namespace LogisticsCenter.Model.ProgramModels
{
    public class User
    {
        public User(DatabaseContext context, Employee employee)
        {
            try
            {
                Login = employee.Login;
                Speciality = employee.Speciality.Name;
                RightsForEntitiesAndFields = Rights.GetListOfEntities(employee.Speciality.RightsList, context);
            }
            catch (NullReferenceException) { throw new NoEmployeeException(); }
            catch (Exception e) { throw e; }
        }

        public List<Entity> RightsForEntitiesAndFields { get; private set; }

        public string Login { get; }

        public string Speciality { get; }
    }

    public class NoEmployeeException : Exception
    {
        public new string Message => "Не была передана сущность работника " +
            "(программная ошибка). Обратитесь к разработчикам программы.";
    }
}