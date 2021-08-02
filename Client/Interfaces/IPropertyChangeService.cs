using System;
using System.Reactive;

namespace JsonlCompare.Client.Interfaces
{
    public interface IPropertyChangeService
    {
        void SignalChange();
        IObservable<Unit> PropertyChangeNotification { get; }
    }
}