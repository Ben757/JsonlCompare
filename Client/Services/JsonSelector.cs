using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using JsonlCompare.Client.Interfaces;
using Newtonsoft.Json.Linq;

namespace JsonlCompare.Client.Services
{
    public class JsonSelector : IJsonSelector, IDisposable
    {
        public IObservable<JObject?> JsonObservable => jsonSubject.AsObservable();
        private readonly Subject<JObject?> jsonSubject = new();

        public void SetJson(JObject? json)
        {
            jsonSubject.OnNext(json);
        }

        public void Dispose()
        {
            jsonSubject.Dispose();
        }
    }
}