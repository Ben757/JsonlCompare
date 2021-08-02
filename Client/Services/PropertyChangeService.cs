using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using JsonlCompare.Client.Interfaces;

namespace JsonlCompare.Client.Services
{
    public class PropertyChangeService : IPropertyChangeService, IDisposable
    {
        private readonly Subject<Unit> propertyChangedSubject = new();
        public IObservable<Unit> PropertyChangeNotification => propertyChangedSubject.AsObservable();

        public void SignalChange()
        {
            propertyChangedSubject.OnNext(Unit.Default);
        }

        public void Dispose()
        {
            propertyChangedSubject.Dispose();
        }
    }
}