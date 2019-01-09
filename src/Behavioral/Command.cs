using System;
using design_patterns.Core;

namespace design_patterns.Behavioral
{

    ///
    /// Encapsulate a request as an object, thereby letting you parameterize clients 
    /// with different requests, queue or log requests, and support undoable operations.
    ///
    /// https://www.dofactory.com/net/command-design-pattern
    ///
    /// https://www.youtube.com/watch?v=9qA5kw8dcSU
    ///

    public interface ICommand
    {
        void Execute();
    }

    public interface IReceiver
    {
        void Action();
    }

    public class Receiver : IReceiver
    {
        public void Action()
        {
            Console.WriteLine("Receiver.Action()");
        }
    }


    public class Invoker
    {
        private readonly ICommand _command;

        public Invoker(ICommand command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }

    public class ConcreteCommand : ICommand
    {
        private readonly IReceiver _receiver;

        public ConcreteCommand( IReceiver receiver)
        {
            _receiver = receiver;
        }

        public virtual void Execute()
        {
            Console.WriteLine("ConcreteCommand.Execute()");
            _receiver.Action();
        }
    }

    public class CommandPatternRunner : IPatternRunner
    {
        public string Key
        {
            get 
            {
                return "H or h";
            }
        }
        public string Title
        {
            get 
            {
                return "Command Pattern";
            }
        }
        
        public bool IsTheOne( ConsoleKeyInfo key)
        {
            return key.KeyChar == 'H' || key.KeyChar == 'h';
        }
        
        public virtual void Run()
        {
            Console.WriteLine();

            var command = new ConcreteCommand(new Receiver());
            var invoker = new Invoker(command);
            invoker.ExecuteCommand();
        }
    }    

}