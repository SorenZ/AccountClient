using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTemplate.server.Services
{
    public class ContactObservable : IObservable<Activity>
    {
        public ContactObservable()
        {
            observers = new List<IObserver<Activity>>();
        }

        private List<IObserver<Activity>> observers;

        public IDisposable Subscribe(IObserver<Activity> observer)
        {
            if (! observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Activity>>_observers;
            private IObserver<Activity> _observer;

            public Unsubscriber(List<IObserver<Activity>> observers, IObserver<Activity> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        public void AddActivity(Activity loc)
        {
            foreach (var observer in observers)
            {
                if (loc != null)
                    observer.OnNext(loc);
                // else
                //     observer.OnError(new LocationUnknownException());
            }
        }
        
        public IObservable<Activity> Populate(IEnumerable<Activity> activities)
        {
            var enumerable = activities.ToList();
            foreach (var observer in observers) {
                foreach (var activity in enumerable)
                {
                    if (activity != null)
                        observer.OnNext(activity);
                    // else
                    //     observer.OnError(new LocationUnknownException());
                }
                
            }

            return this;
        }

        public void EndTransmission()
        {
            foreach (var observer in observers.ToArray())
                if (observers.Contains(observer))
                    observer.OnCompleted();

            observers.Clear();
        }
    }

    public class LocationUnknownException : Exception
    {
    }
}