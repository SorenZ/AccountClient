using System;
using mytemplate;

namespace MyTemplate.server.Services
{
    public class ContactObserver : IObserver<Activity>
    {
        private IDisposable unsubscriber;
        private string instName;

        public ContactObserver(string name)
        {
            this.instName = name;
        }

        public string Name
        {  get{ return this.instName; } }

        public virtual void Subscribe(IObservable<Activity> provider)
        {
            if (provider != null)
                unsubscriber = provider.Subscribe(this);
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine("The Location Tracker has completed transmitting data to {0}.", this.Name);
            this.Unsubscribe();
        }

        public virtual void OnError(Exception e)
        {
            Console.WriteLine("{0}: The location cannot be determined.", this.Name);
        }

        public virtual void OnNext(Activity value)
        {
            Console.WriteLine("{2}: The current location is {0}, {1}", value.Id, value.PersonName, this.Name);
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }
    }
}