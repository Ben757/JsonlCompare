using System.Collections.Generic;
using JsonlCompare.Client.Models;
using Newtonsoft.Json.Linq;

namespace JsonlCompare.Client.Interfaces
{
    public interface IPropertyInfoService
    {
        IReadOnlyList<JsonPropertyInfo> PropertyInfos(IReadOnlyList<JObject> jsons);
    }
}