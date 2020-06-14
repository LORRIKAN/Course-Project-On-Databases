using Force.DeepCloner;
using LogisticsCenter.Model;
using LogisticsCenter.Model.ProgramModels;
using LogisticsCenter.Repository;
using LogisticsCenter.Views.Filling;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace LogisticsCenter.Presenters.Filling
{
    public class FillingPresenter<TEntity> : IFillingPresenter where TEntity : class, IModel
    {
        protected DatabaseContext Context { get; set; }

        protected IFillingForm FillingForm { get; set; }

        protected IModel ModelClone { get; set; }

        protected IModel Model { get; set; }

        protected FillType FillType { get; set; }

        readonly string NL = Environment.NewLine;

        public event Action PresenterClosure;

        public event Action<FillType> FillingCompleted;

        public FillingPresenter(DatabaseContext context, IFillingForm fillingForm)
        {
            Context = context;
            FillingForm = fillingForm;
            FillingForm.CheckProperty += FillingForm_CheckProperty;
            FillingForm.CheckModel += FillingForm_CheckModel;
            FillingForm.SuccessfullyFilled += (model) =>
            {
                ModelClone.DeepCloneTo(Model);
                FillingCompleted.Invoke(FillType);
            };
            FillingForm.FormClosure += () => PresenterClosure.Invoke();
        }

        public virtual void Run(User user, IModel model, FillType addOrUpdate)
        {
            FillType = addOrUpdate;
            Model = model;
            ModelClone = model.DeepClone();
            var correctedModel = SetRights(ModelClone, user);
            FillingForm.Show(correctedModel);
        }

        protected IModel SetRights(IModel model, User user)
        {
            if (FillType == FillType.Add)
                return model;

            var props = model.GetType().GetProperties();
            foreach (var prop in props)
            {
                PropertyDescriptor descriptor = TypeDescriptor.GetProperties(model.GetType())[prop.Name];
                ReadOnlyAttribute attrib = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
                if (attrib != null)
                {
                    bool isReadOnlyFromRights = !user.RightsForEntitiesAndFields
                        .Any(a => a.EntityType == model.GetType().BaseType
                        && a.Fields.Any(f => f.FieldProperty.Name == prop.Name && f.Updatable));
                    FieldInfo isReadOnly = attrib.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
                    isReadOnly.SetValue(attrib, isReadOnlyFromRights);
                }
            }
            return model;
        }

        protected virtual string FillingForm_CheckProperty(string propertyName, object propertyValue)
        {
            var results = CheckProperty(propertyName, propertyValue);
            string resultsStr = null;
            foreach (var result in results)
            {
                resultsStr += result.ErrorMessage + NL;
            }
            return resultsStr;
        }

        protected List<ValidationResult> CheckProperty(string propName, object value)
        {
            var cntx = new ValidationContext(ModelClone) { MemberName = propName };
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(value, cntx, results);
            return results;
        }

        protected virtual string FillingForm_CheckModel(IModel model)
        {
            var results = CheckObject(model);
            string resultsStr = null;

            if (results.Any())
                foreach (var result in results)
                {
                    resultsStr += result.ErrorMessage + NL;
                }
            else
            {
                try
                {
                    if (FillType == FillType.Add)
                        Context.Add(model);
                    else
                        Context.Update(model);
                    Context.TrySave();
                }
                catch
                {
                    resultsStr = "Ошибка. Она могла возникнуть из-за неверных значений аттрибутов, " +
                        "зависимых от других сущностей (ID, ключи и т.п.).";
                    Context.Remove(model);
                }
            }

            return resultsStr;
        }

        protected List<ValidationResult> CheckObject(IModel model)
        {
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(model, context, results);
            return results;
        }
    }

    public enum FillType
    {
        Add,
        Update
    }
}