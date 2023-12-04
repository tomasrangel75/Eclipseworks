using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipseworks.Shared
{
    public static class Clone
    {
        public static T CreateNonReferencedObject<T>(this T obj)
        {
            var tObj = (T)Activator.CreateInstance(typeof(T));

            if (obj == null) return tObj;

            var properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(obj);
                tObj.GetType().GetProperty(property.Name).SetValue(tObj, value);
            }

            return tObj;
        }
    }
}
