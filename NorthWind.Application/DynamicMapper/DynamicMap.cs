using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace NorthWind.Application.DynamicMapper
{
    public static class DynamicMap
    {
        public static TEntity ToEntity<TEntity>(object expando)
        {
            var entity = Activator.CreateInstance<TEntity>();

            //ExpandoObject implements dictionary
            var properties = expando as IDictionary<string, object>;

            if (properties == null)
                return entity;

            foreach (var entry in properties)
            {
                var propertyInfo = entity.GetType().GetProperty(entry.Key, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                if (propertyInfo != null)
                {                    
                    var result = Convert.ChangeType(entry.Value, propertyInfo.PropertyType);
                    propertyInfo.SetValue(entity, result, null);
                }
                    
            }
            return entity;
        }

        public static ExpandoObject ToExpandoObj(object entityObject)
        {
            PropertyInfo[] properties = entityObject.GetType().GetProperties();

            if (properties == null || properties.Length == 0)
            {
                return null;
            }

            dynamic expando = new ExpandoObject();
            var dict = expando as IDictionary<string, object>;

            foreach (var property in properties)
            {
                dict[ToJsonCamelCaseFormat(property.Name)] = property.GetValue(entityObject, null);
            }

            return expando;
        }

        private static string ToJsonCamelCaseFormat(string value)
        {
            var result = value.First().ToString().ToLower() + value.Substring(1);
            return result;
        }
    }
}
