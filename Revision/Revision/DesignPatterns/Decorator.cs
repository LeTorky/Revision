using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision.DesignPatterns
{
    //Class Interface
    public interface IClass
    {
        void DoWork();
    }
    //Concrete Class
    public class ConcClass : IClass
    {
        public void DoWork()
        {
            Console.WriteLine("Implementing IClass");
        }
    }
    //Decorator Interface (Used as a wrapper)
    public interface IDecorator
    {
        void DecoratorDoWork();
    }
    //Concrete Decorator
    public class Decorator : IDecorator
    {
        protected IDecorator? _decorator;
        protected IClass? _class;
        public Decorator(IClass SetClass):this(null, SetClass)
        {
        }
        public Decorator(IDecorator SetDecorator, IClass SetClass)
        {
            _decorator = SetDecorator;
            _class = SetClass;
        }
        public void DecoratorDoWork()
        {
            if( _decorator != null )
                _decorator.DecoratorDoWork();
            _class?.DoWork();
        }
    }
}
