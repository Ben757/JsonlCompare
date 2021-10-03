using System.Collections.Generic;
using JsonlCompare.Client.Models;

namespace JsonlCompare.Client.Extensions
{
    public static class JsonPropertyInfoExtensions
    {
        public static IEnumerable<JsonPropertyInfo> EnumerateChildren(this JsonPropertyInfo propertyInfo)
        {
            yield return propertyInfo;
            if (!propertyInfo.HasChildren) yield break;
        
            foreach (var propertyInfoChild in propertyInfo.Children)
            {
                foreach (var jsonPropertyInfo in EnumerateChildren(propertyInfoChild))
                    yield return jsonPropertyInfo;
            }
        }
    }
}