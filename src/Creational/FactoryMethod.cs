using System;
using System.Collections.Generic;
using design_patterns.Core;


namespace design_patterns.Creational
{
    ///
    /// Define an interface for creating an object, but let subclasses decide which class to instantiate.
    ///
    /// https://www.dofactory.com/net/factory-method-design-pattern
    ///
    /// https://www.youtube.com/watch?v=EcFVTgRHJLM
    ///

    public interface IProductFactory
    {
        IProduct Create();
    }

    public class ProductAFactory : IProductFactory
    {
        public virtual IProduct Create()
        {
            return new ProductA();
        }
    }
    public class ProductBFactory : IProductFactory
    {
        public virtual IProduct Create()
        {
            return new ProductB();
        }
    }

    public class FactoryMethodRunner : IPatternRunner
    {
        public string Key
        {
            get 
            {
                return "B or b";
            }
        }
        public string Title
        {
            get 
            {
                return "Factory Method";
            }
        }
        
        public bool IsTheOne( ConsoleKeyInfo key)
        {
            return key.KeyChar == 'B' || key.KeyChar == 'b';
        }
        
        public virtual void Run()
        {
            var factories = new List<IProductFactory>(){
                new ProductAFactory(),
                new ProductBFactory()
            };
            
            Console.WriteLine();
            foreach( var factory in factories)        
            {
                var product = factory.Create();
                Console.WriteLine($"Product {product.Name} has been created.");
            }
        }
    }
}