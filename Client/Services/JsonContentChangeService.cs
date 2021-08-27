using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using JsonlCompare.Client.Interfaces;

namespace JsonlCompare.Client.Services
{
    public class JsonContentChangeService : IJsonContentChangeService, IDisposable
    {
        private readonly Subject<Unit> jsonContentChangedSubject = new();
        public IObservable<Unit> JsonContentChangeNotification => jsonContentChangedSubject.AsObservable();

        public void SignalChange()
        {
            jsonContentChangedSubject.OnNext(Unit.Default);
        }

        public void Dispose()
        {
            jsonContentChangedSubject.Dispose();
        }
    }
}