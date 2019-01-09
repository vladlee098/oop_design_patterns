using System;
using System.Collections.Generic;
using design_patterns.Core;

namespace design_patterns.Creational
{
    
    ///
    /// Provide an interface for creating families of related or dependent objects without specifying their concrete classes
    ///
    /// https://www.dofactory.com/net/abstract-factory-design-pattern
    ///
    /// https://www.youtube.com/watch?v=v-GiuMmsXj4
    ///
    
    public interface IAbstractFactory
    {
        IProduct CreateProductA();
        IProduct CreateProductB();
    }

    public class ConcreteProductA : ProductA
    {
        private string _creator;
        public ConcreteProductA( string creator )
        {
            _creator = creator;
        }

        public override string Name
        {
            get
            {
                return _creator + " - " + base.Name;
            }
        }
    }

    public class ConcreteProductB : ProductB
    {
        private string _creator;
        public ConcreteProductB( string creator )
        {
            _creator = creator;
        }

        public override string Name
        {
            get
            {
                return _creator + " - " + base.Name;
            }
        }
    }

    public class ConcreteFactoryA : IAbstractFactory
    {
        public virtual IProduct CreateProductA()
        {
            return new ConcreteProductA("FactoryA");
        }
        public virtual IProduct CreateProductB()
        {
            return new ConcreteProductB("FactoryA");
        }
    }

    public class ConcreteFactoryB : IAbstractFactory
    {
        public virtual IProduct CreateProductA()
        {
            return new ConcreteProductA("FactoryB");
        }
        public virtual IProduct CreateProductB()
        {
            return new ConcreteProductB("FactoryB");
        }
    }
    
    public class AbstractFactoryRunner : IPatternRunner
    {
        public string Key
        {
            get 
            {
                return "D or d";
            }
        }
        public string Title
        {
            get 
            {
                return "Abstract Factory";
            }
        }
        
        public bool IsTheOne( ConsoleKeyInfo key)
        {
            return key.KeyChar == 'D' || key.KeyChar == 'd';
        }
        
        public virtual void Run()
        {
            var factories = new List<IAbstractFactory>(){
                new ConcreteFactoryA(),
                new ConcreteFactoryB()
            };
            
            Console.WriteLine();
            foreach( var factory in factories)        
            {
                var productA = factory.CreateProductA();
                var productB = factory.CreateProductB();

                Console.WriteLine($"{productA.Name} has been created.");
                Console.WriteLine($"{productB.Name} has been created.");
            }
        }
    }    
}