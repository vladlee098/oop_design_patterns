using System;
using System.Text;
using System.Collections.Generic;

using design_patterns.Core;

namespace design_patterns.Structural
{
    
    ///
    /// Compose objects into tree structures to represent part-whole hierarchies. 
    /// Composite lets clients treat individual objects and compositions of objects uniformly.
    ///
    /// https://www.dofactory.com/net/composite-design-pattern
    ///
    /// https://www.youtube.com/watch?v=EWDmWbJ4wRA
    ///    
    
    /// Component
    public interface ToDoList
    {
        string GetHtml();
    }

    /// Leaf
    public class ToDo : ToDoList
    {
        readonly string _text;

        public ToDo(string text)
        {
            _text = text;
        }

        public virtual string GetHtml()
        {
            var html = new StringBuilder();
            
            html.Append("<li>");
            html.Append(_text);
            html.AppendLine("</li>");

            return html.ToString();
        }
    }

    /// Composite
    public class Project : ToDoList
    {
        readonly string _title;
        readonly List<ToDoList> _todos;

        public Project( string title, List<ToDoList> todos)
        {
            _title = title;
            _todos = todos;
        }

        public virtual string GetHtml()
        {
            var html = new StringBuilder();

            html.Append("<h1>");
            html.Append(_title);
            html.AppendLine("</h1>");

            html.AppendLine("<ul>");
            foreach( var todo in _todos)
            {
                html.Append(todo.GetHtml());
            }
            html.AppendLine("</ul>");
            return html.ToString();
        }
    }

   public class CompositePatternRunner : IPatternRunner
    {
        public string Key
        {
            get 
            {
                return "K or k";
            }
        }
        public string Title
        {
            get 
            {
                return "Compisite Pattern";
            }
        }
        
        public bool IsTheOne( ConsoleKeyInfo key)
        {
            return key.KeyChar == 'K' || key.KeyChar == 'k';
        }
        
        public virtual void Run()
        {
            Console.WriteLine();

            var tasks = new List<ToDoList>()
            {
                new ToDo("task1"),
                new ToDo("task2"),
                new ToDo("task3")
            };

            var project = new Project("My ToDo tasks", tasks);
            Console.WriteLine(project.GetHtml());
        }
    }    
}