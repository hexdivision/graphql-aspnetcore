using System;
using System.Collections.Generic;
using System.Reflection;

namespace PathWays.Common.Utilities
{
    public static class PatchHelper
    {
        public static T PatchFromDictionary<T>(this T request, IReadOnlyDictionary<string, object> dict)
        {
            foreach (var item in dict)
            {
                PropertyInfo property = request.GetType().GetProperty(item.Key, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                // Find which property type (int, string, double? etc) the CURRENT property is...
                Type tPropertyType = property.PropertyType;

                if (IsComplex(tPropertyType))
                {
                    throw new ArgumentException("Complex types are not supported");
                }

                // Fix nullables...
                Type newT = Nullable.GetUnderlyingType(tPropertyType) ?? tPropertyType;

                // ...and change the type
                object newA = Convert.ChangeType(item.Value, newT);
                property.SetValue(request, newA, null);
            }

            return request;
        }

        public static bool IsComplex(Type typeIn)
        {
            if (typeIn.IsSubclassOf(typeof(System.ValueType)) || typeIn.Equals(typeof(string)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
