using System;
using design_patterns.Core;

namespace design_patterns.Structural
{

    ///
    /// Provide a surrogate or placeholder for another object to control access to it.
    ///
    /// https://www.dofactory.com/net/proxy-design-pattern
    ///
    /// https://www.youtube.com/watch?v=NwaabHqPHeM
    ///


    public interface IMath 
    {
        void Operation();
    }

    public class Math : IMath
    {
        public virtual void Operation()
        {
            Console.WriteLine("Math.Operation()");
        }
    }

    public class Proxy : IMath
    {
        private readonly IMath _subject;
        
        public Proxy(IMath subject)
        {
            _subject = subject;
        }
        
        public virtual void Operation()
        {
            Console.WriteLine("Proxy.Operation()");
            _subject.Operation();
        }
    }

    public class ProxyPatternRunner : IPatternRunner
    {
        public string Key
        {
            get 
            {
                return "G or g";
            }
        }
        public string Title
        {
            get 
            {
                return "Proxy Pattern";
            }
        }
        
        public bool IsTheOne( ConsoleKeyInfo key)
        {
            return key.KeyChar == 'G' || key.KeyChar == 'g';
        }
        
        public virtual void Run()
        {
            Console.WriteLine();

            var proxy = new Proxy( new Math() );
            proxy.Operation();
        }
    }    
}