using System;
using System.Collections.Generic;

using design_patterns.Core;

namespace design_patterns.Structural
{
    ///
    /// Convert the interface of a class into another interface clients expect.
    ///
    /// https://www.dofactory.com/net/adapter-design-pattern
    ///
    /// https://www.youtube.com/watch?v=2PKQtcJjYvc
    ///
    
    public interface ITarget
    {
        void Request();
    }


    public class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Adaptee.SpecificRequest()");
        }
    }

    public class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter( Adaptee adaptee)
        {
            _adaptee = adaptee;
        }
        public void Request()
        {
            _adaptee.SpecificRequest();
        }
    }

    public class AdapterPatternRunner : IPatternRunner
    {
        public string Key
        {
            get 
            {
                return "F or f";
            }
        }
        public string Title
        {
            get 
            {
                return "Adapter Pattern";
            }
        }
        
        public bool IsTheOne( ConsoleKeyInfo key)
        {
            return key.KeyChar == 'F' || key.KeyChar == 'f';
        }
        
        public virtual void Run()
        {
            Console.WriteLine();
            
            var adapter = new Adapter(new Adaptee() );
            adapter.Request();
        }
    }        
}