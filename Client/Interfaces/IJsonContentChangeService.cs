using System;
using System.Reactive;

namespace JsonlCompare.Client.Interfaces
{
    public interface IJsonContentChangeService
    {
        void SignalChange();
        IObservable<Unit> JsonContentChangeNotification { get; }
    }
}