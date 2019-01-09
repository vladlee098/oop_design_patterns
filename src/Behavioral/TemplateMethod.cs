using System;
using design_patterns.Core;

namespace design_patterns.Behavioral
{

    ///
    /// Define the skeleton of an algorithm in an operation, deferring some steps to subclasses. 
    /// Template Method lets subclasses redefine certain steps of an algorithm without changing the algorithm's structure.
    ///
    /// https://www.dofactory.com/net/template-method-design-pattern
    ///
    /// https://www.youtube.com/watch?v=7ocpwK9uesw
    ///

    public abstract class AbstractClass
    {
        protected abstract void Operation1();
        protected abstract void Operation2();
        protected abstract void Operation3();

        public void TemplateMethod()
        {
            Operation1();
            Operation2();
            Operation3();
        }
    }


    public class ConcreteClassA : AbstractClass
    {
        protected override void Operation1()
        {
            Console.WriteLine("ConcreteClassA.Operation1()");
        }
        protected override void Operation2()
        {
            Console.WriteLine("ConcreteClassA.Operation2()");
        }
        protected override void Operation3()
        {
            Console.WriteLine("ConcreteClassA.Operation3()");
        }
    }

    public class ConcreteClassB : AbstractClass
    {
        protected override void Operation1()
        {
            Console.WriteLine("ConcreteClassB.Operation1()");
        }
        protected override void Operation2()
        {
            Console.WriteLine("ConcreteClassB.Operation2()");
        }
        protected override void Operation3()
        {
            Console.WriteLine("ConcreteClassB.Operation3()");
        }
    }

    public class TemplateMethodRunner : IPatternRunner
    {
        public string Key
        {
            get 
            {
                return "J or j";
            }
        }
        public string Title
        {
            get 
            {
                return "Template Method";
            }
        }
        
        public bool IsTheOne( ConsoleKeyInfo key)
        {
            return key.KeyChar == 'J' || key.KeyChar == 'j';
        }
        
        public virtual void Run()
        {
            Console.WriteLine();

            var classA = new ConcreteClassA();
            classA.TemplateMethod();

            var classB = new ConcreteClassB();
            classB.TemplateMethod();
        }
    }    

}