using System;
using System.Collections.Generic;

using design_patterns.Core;


namespace design_patterns.Structural
{
    ///
    /// Decouple an abstraction from its implementation so that the two can vary independently.
    ///
    /// https://www.dofactory.com/net/bridge-design-pattern
    ///
    /// https://www.youtube.com/watch?v=F1YQ7YRjttI
    ///    

    public interface IImplementor
    {
        void OperationImpl();
    }

    public abstract class Abstraction
    {
        protected readonly IImplementor _implementor;

        public Abstraction( IImplementor implementor)
        {
            _implementor = implementor;
        }

        public abstract void Operation();
    }

    public class RefinedAbstraction : Abstraction
    {
        public RefinedAbstraction(IImplementor implementor) : base(implementor)
        {
        }

        public override void Operation()
        {
            _implementor.OperationImpl();
        }
    }

    public class ConcreteImplementorA : IImplementor
    {
        public virtual void OperationImpl()
        {
            Console.WriteLine("ConcreteImplementorA - OperationImpl");
        }
    }    

    public class ConcreteImplementorB : IImplementor
    {
        public virtual void OperationImpl()
        {
            Console.WriteLine("ConcreteImplementorB - OperationImpl");
        }
    }    

    public class BridgePatternRunner : IPatternRunner
    {
        public string Key
        {
            get 
            {
                return "E or e";
            }
        }
        public string Title
        {
            get 
            {
                return "Bridge Pattern";
            }
        }
        
        public bool IsTheOne( ConsoleKeyInfo key)
        {
            return key.KeyChar == 'E' || key.KeyChar == 'e';
        }
        
        public virtual void Run()
        {
            Console.WriteLine();

            var abstractionA = new RefinedAbstraction(new ConcreteImplementorA() );
            abstractionA.Operation();

            var abstractionB = new RefinedAbstraction(new ConcreteImplementorB() );
            abstractionB.Operation();
        }
    }    
}