using System;
using System.Collections.Generic;
using System.Linq;

using design_patterns.Core;
using design_patterns.Behavioral;
using design_patterns.Creational;
using design_patterns.Structural;

namespace design_patterns
{
    class Program
    {
        static List<IPatternRunner> CreatePatternRunners()
        {
            return new List<IPatternRunner>()
            {
                new PaymentStrategyRunner(),
                new FactoryMethodRunner(),
                new ObserverRunner(),
                new AbstractFactoryRunner(),
                new BridgePatternRunner(),
                new AdapterPatternRunner(),
                new ProxyPatternRunner(),
                new CommandPatternRunner(),
                new TemplateMethodRunner(),
                new CompositePatternRunner(),
            };
        }
        
        static void Main(string[] args)
        {
            var runners = CreatePatternRunners();
         
            while(true)
            {
                Console.Clear();
                Console.WriteLine("List of available Patterns:");
                foreach( var pattern in runners)
                {
                    Console.WriteLine($" - {pattern.Title}: to execute, press '{pattern.Key}'");
                }

                Console.Write(">>");
                var keyInfo = Console.ReadKey();

                var runner = runners.FirstOrDefault( r => r.IsTheOne(keyInfo) );
                if (runner != null)
                {
                    runner.Run();
                }
                else
                {
                    Console.WriteLine("Matching pattern not found.");
                }

                Console.WriteLine($"--------------------------");
                Console.WriteLine($">> press ANY KEY to continue or ESC to quit");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }

            }
        }
    }
}
