using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision.DesignPatterns
{
    //Strategy Interface for multipe implementations
    public interface IStrategy
    {
        //Do Work method to be implemented
        void DoWork();
    }
    //First Strategy Concrete class with its own strategy
    public class StrategyOne : IStrategy
    {
        public void DoWork()
        {
            Console.WriteLine("Work via method A");
        }
    }
    //Second Strategy Concrete class with its own strategy
    public class StrategyTwo : IStrategy
    {
        public void DoWork()
        {
            Console.WriteLine("Work via method A");
        }
    }
    //Context class which holds strategy
    public class Context
    {
        //Strategy instace which holds implementation of method
        public IStrategy Strategy { private get; set; }
        //Constructor
        public Context(IStrategy strategy)
        {
            Strategy = strategy;
        }
        //Do Work method which invokes the strategy method
        public void DoWork()
        {
            Strategy.DoWork();
        }
    }
}
