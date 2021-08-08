using System;
using Newtonsoft.Json.Linq;

namespace JsonlCompare.Client.Interfaces
{
    public interface IJsonSelector
    {
        IObservable<JObject?> JsonObservable { get; }
        void SetJson(JObject? json);
    }
}