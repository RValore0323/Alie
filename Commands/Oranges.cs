using System;
using Alie;

namespace Commands
{
    public class Oranges : IAction
    {
        public Result Run(string[] Parameters)
        {
            Console.WriteLine("The Answer To Life, The Universe, And Everything Is 42");
            return new Result();
        }

    }
}
