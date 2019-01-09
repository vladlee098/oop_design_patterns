using System;
using System.Collections.Generic;
using design_patterns.Core;


namespace design_patterns.Behavioral
{
    ///
    /// Define a one-to-many dependency between objects so that when one object changes state, 
    /// all its dependents are notified and updated automatically.
    ///
    /// https://www.dofactory.com/net/observer-design-pattern
    ///
    /// https://www.youtube.com/watch?v=_BpmfnqjgzQ
    /// 
    
    public interface IObserver
    {
        void Update();
    }

    public interface IObservable
    {
        void Add( IObserver observer);
        void Remove( IObserver observer);
        void Notify();
    }


    public class ConcreteObserver : IObserver
    {
        public virtual void Update()
        {
            Console.WriteLine("Observer notified.");
        }
    }

    public class ConcreteObservable : IObservable
    {
        private List<IObserver> _observers = new List<IObserver>();


        public virtual void Add( IObserver observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer); 
        }
        public virtual void Remove( IObserver observer)
        {
            if (_observers.Contains(observer))
                _observers.Remove(observer); 
        }
        public virtual void Notify()
        {
            _observers.ForEach( o => {
                o.Update();
            });
        }
    }


    public class ObserverRunner : IPatternRunner
    {
        public string Key
        {
            get 
            {
                return "C or c";
            }
        }
        public string Title
        {
            get 
            {
                return "Observer Pattern";
            }
        }
        
        public bool IsTheOne( ConsoleKeyInfo key)
        {
            return key.KeyChar == 'C' || key.KeyChar == 'c';
        }
        
        public virtual void Run()
        {
            var observable = new ConcreteObservable();
            observable.Add(new ConcreteObserver());
            observable.Add(new ConcreteObserver());
            observable.Add(new ConcreteObserver());

            Console.WriteLine();
            observable.Notify();
        }
    }    

}