using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace NorthWind.Application.DynamicMapper
{
    public static class DynamicToEntity
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
                    propertyInfo.SetValue(entity, entry.Value, null);
            }
            return entity;
        }
    }
}
