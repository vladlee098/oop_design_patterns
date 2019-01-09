using System;

namespace design_patterns.Core
{
    public interface IPatternRunner
    {
        void Run();
        string Key { get; }
        bool IsTheOne( ConsoleKeyInfo key);
        string Title { get; }
    }
}
