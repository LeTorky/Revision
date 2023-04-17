using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision.DesignPatterns
{
    //Event interface for multiple event types
    public interface IEvent
    {
        //Method to return Event Id
        string Describe();
    }
    //Event concrete class
    public class Event : IEvent
    {
        //Event Id to distinguish it from other events
        public string EventId { get; private set; }
        //Constructor
        public Event()
        {
            //Sets EventId to a unique name.
            EventId = "EventOne";
        }
        //Implementing IEvent
        public string Describe()
        {
            return EventId;
        }

    }
    //Observer Interface for multiple observers
    public interface IObserver
    {
        //Method to get updated with
        void Update();
    }
    //Observer concrete class
    public class Observer:IObserver
    {
        //Implemetning Observer Interface
        public void Update()
        {
            Console.WriteLine("Ive been updated!");
        }
    }
    //Event Manager Interface for multiple event managers
    public interface IEventManager
    {
        void Subscribe(IEvent EventType, IObserver Subscriber);
        void UnSubscribe(IEvent EventType, IObserver Subscriber);
        void Notify(IEvent EventType);
    }
    //Subscription class to hold an event id and observers
    public class Subscription
    {
        //List of observers
        public List<IObserver> Observers { get; private set; }
        //Event id of this subscription
        public IEvent Event { get; private set; }
        //Constructor to set unique event id for each subscription
        public Subscription(IEvent EventType)
        {
            Observers= new List<IObserver>();
            Event = EventType;
        }
    }
    //Event Manager Concrete Class
    public class EventManager : IEventManager
    {
        //Set of Subscribers
        private HashSet<Subscription> Subscribers;
        //Constructor
        public EventManager()
        {
            Subscribers = new HashSet<Subscription>();
        }
        //Creates a new Event
        private void CreateEvent(IEvent EventType)
        {
            Subscribers.Add(new Subscription(EventType));
        }
        //Invokes Update method on all Subscribers
        public void Notify(IEvent EventType)
        {
            Subscribers.Where(Sub => Sub.Event.Describe() == EventType.Describe()).FirstOrDefault()
                .Observers.ForEach(Obs => Obs.Update());
        }
        //Subscribes an Observer to a specific Event
        public void Subscribe(IEvent EventType, IObserver Subscriber)
        {
            Subscription Subscription = Subscribers.Where(Sub => Sub.Event.Describe() == EventType.Describe()).FirstOrDefault();
            if (Subscription == null)
            {
                CreateEvent(EventType);
                Subscription = Subscribers.Where(Sub => Sub.Event.Describe() == EventType.Describe()).FirstOrDefault();
            }
            if(!Subscription.Observers.Contains(Subscriber))
                Subscription.Observers.Add(Subscriber);
        }
        //Unsucribes an Observer form a specific Event
        public void UnSubscribe(IEvent EventType, IObserver Subscriber)
        {
            Subscription Subscription = Subscribers.Where(Sub => Sub.Event.Describe() == EventType.Describe()).FirstOrDefault();
            if (Subscription != null)
                Subscription.Observers.Remove(Subscriber);
        }
    }
    //Publisher Interface for many publishers
    public interface IPublisher
    {
        void Publish(IEvent EventType);
    }
    //Publisher Concrete Class
    public class Publisher : IPublisher
    {
        //Event Manager Instance
        public IEventManager EventManger { get; private set; }
        //Constructor
        public Publisher(IEventManager SetEventManager)
        {
            EventManger = SetEventManager;
        }
        //Invokes EventManagers Notify
        public void Publish(IEvent EventType) 
        {
            EventManger.Notify(EventType);
        }
    }


}
