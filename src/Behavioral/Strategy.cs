using System;
using System.Collections.Generic;
using design_patterns.Core;

namespace design_patterns.Behavioral
{
    
    ///
    /// Define a family of algorithms, encapsulate each one, and make them interchangeable. 
    /// Strategy lets the algorithm vary independently from clients that use it.
    ///
    /// https://www.dofactory.com/net/strategy-design-pattern
    ///
    /// https://www.youtube.com/watch?v=v9ejT8FO-7I
    ///    
    
    public interface IPaymentStrategy
    {
        void Pay();
    }

    public class DebitStrategy : IPaymentStrategy
    {
        public virtual void Pay()
        {
            Console.WriteLine("paying by debit card");
        }
    }

    public class CreditStrategy : IPaymentStrategy
    {
        public virtual void Pay()
        {
            Console.WriteLine("paying by credit card");
        }
    }

    public class CashStrategy : IPaymentStrategy
    {
        public virtual void Pay()
        {
            Console.WriteLine("paying by cash");
        }
    }

    public class StrategyCustomer
    {
        IPaymentStrategy _strategy;

        public StrategyCustomer(IPaymentStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Pay()
        {
            _strategy.Pay();
        }
    }

    public class PaymentStrategyRunner : IPatternRunner
    {
        public string Key
        {
            get 
            {
                return "A or a";
            }
        }
        public string Title
        {
            get 
            {
                return "Strategy Pattern";
            }
        }
        
        public bool IsTheOne( ConsoleKeyInfo key)
        {
            return key.KeyChar == 'A' || key.KeyChar == 'a';
        }
        
        public virtual void Run()
        {
            var customers = new List<StrategyCustomer>(){
                new StrategyCustomer( new DebitStrategy() ),
                new StrategyCustomer( new CreditStrategy() ),
                new StrategyCustomer( new CashStrategy() ),
            };
            
            Console.WriteLine();
            foreach( var customer in customers)        
            {
                customer.Pay();
            }
        }
    }
}
