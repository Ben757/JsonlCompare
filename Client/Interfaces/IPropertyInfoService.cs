using System.Collections.Generic;
using JsonlCompare.Client.Models;

namespace JsonlCompare.Client.Interfaces
{
    public interface IPropertyInfoService
    {
        IReadOnlyList<JsonPropertyInfo> PropertyInfos { get; }
    }
}