using System.Collections.Generic;
using JsonlCompare.Client.Models;

namespace JsonlCompare.Client.Interfaces
{
    public interface IPropertyInfoService
    {
        IEnumerable<JsonPropertyInfo> GetPropertyContainer();
    }
}