using System;
using System.Collections.Generic;
using System.Linq;

namespace JsonlCompare.Client.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Flatten<T>(this T value, Func<T, IEnumerable<T>> selector)
        {
            var list = new List<T> { value };
            foreach (var subValue in selector(value))
            {
                list.AddRange(subValue.Flatten(selector));
            }

            return list.AsEnumerable();
        }
        
        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> values, Func<T, IEnumerable<T>> selector)
        {
            var list = new List<T>();
            
            foreach (var subValue in values)
            {
                list.Add(subValue);
                list.AddRange(subValue.Flatten(selector));
            }

            return list.AsEnumerable();
        }
    }
}