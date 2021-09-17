using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace JsonlCompare.Client.Interfaces
{
    public interface IJsonContainer
    {
        IReadOnlyList<JObject> Jsons { get; }
        void Add(JObject json);
        void Clear();
    }
}