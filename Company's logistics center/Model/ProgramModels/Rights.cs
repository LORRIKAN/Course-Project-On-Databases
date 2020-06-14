using LogisticsCenter.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LogisticsCenter.Model.ProgramModels
{
    public static class Rights
    {
        public static List<Entity> GetListOfEntities(string listOfRights, DatabaseContext context)
        {
            var entities = new List<Entity>();

            var entityTypes = context.Model.GetEntityTypes();

            var arrOfRights = listOfRights.Split(';');

            for (int i = 0; i < arrOfRights.Length; ++i)
            {
                var right = arrOfRights[i];

                if (right.StartsWith(" ")) right = right.Remove(0, 1);

                var entityStr = right.TakeWhile(a => a != ':').String();
                Type entity;
                try
                {
                    entity = entityTypes
                        .Single(t => ((DisplayNameAttribute)Attribute
                        .GetCustomAttribute(t.ClrType, typeof(DisplayNameAttribute)))
                        .DisplayName == entityStr)
                        .ClrType;
                }
                catch
                {
                    throw new Exception($"Таблицы '{entityStr}' нет в списке таблиц. " +
                $"Это могло возникнуть из-за неверного заполнения списка прав специальности или из-за " +
                $"модификации базы данных вне программы.");
                }

                right = right.Remove(0, entityStr.Length + 2); // 2 из-за двоеточия и пробела

                var fieldsStr = right.TakeWhile(s => s != '.').String().Split(',');
                var fields = new List<Field>();
                for (int j = 0; j < fieldsStr.Length; ++j)
                {
                    var fieldStr = fieldsStr[j];
                    if (fieldStr.StartsWith(" ")) fieldStr = fieldStr.Remove(0, 1);

                    var updatable = fieldStr.Contains("Обновление");
                    if (updatable) fieldStr = fieldStr.Replace(" Обновление", "");

                    PropertyInfo fieldProperty;
                    try
                    {
                        fieldProperty = (from e in entity.GetProperties()
                                         where e.GetCustomAttributes().Any(a => a is DisplayNameAttribute d
                                            && d.DisplayName == fieldStr)
                                         select e).Single();
                    }
                    catch (Exception)
                    {
                        throw new Exception($"Столбца '{fieldStr}' нет в таблице '{entityStr}'. " +
        $"Это могло возникнуть из-за неверного заполнения списка прав специальности или из-за " +
        $"модификации базы данных вне программы.");
                    }
                    fields.Add(new Field(fieldProperty, updatable));
                }

                var tableRightsStr = right.SkipWhile(s => s != '.').String();
                var addRows = tableRightsStr.Contains("Добавление");
                var deleteRows = tableRightsStr.Contains("Удаление");
                var confirmOrders = tableRightsStr.Contains("Подтверждение заказов");

                entities.Add(new Entity(entity, addRows, deleteRows, fields, confirmOrders));
            }
            return entities;
        }
    }

    public class Entity
    {
        public Entity(Type entity, bool addRows, bool deleteRows, List<Field> fields, bool confirmOrders)
        {
            EntityType = entity;
            AddRowsRight = addRows;
            DeleteRowsRight = deleteRows;
            Fields = fields;
            ConfirmOrders = confirmOrders;
        }
        public Type EntityType { get; private set; }

        public bool AddRowsRight { get; private set; }

        public bool DeleteRowsRight { get; private set; }

        public bool ConfirmOrders { get; private set; }

        public List<Field> Fields { get; private set; }
    }

    public class Field
    {
        public Field(PropertyInfo fieldProperty, bool updatable)
        {
            FieldProperty = fieldProperty;
            Updatable = updatable;
        }

        public PropertyInfo FieldProperty { get; private set; }

        public bool Updatable { get; private set; }
    }

    static class FromCharsToStringExtension
    {
        public static string String(this IEnumerable<char> charSequence)
        {
            var sb = new StringBuilder();
            foreach (var c in charSequence)
            {
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}