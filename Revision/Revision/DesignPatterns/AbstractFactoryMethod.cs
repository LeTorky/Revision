using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision.DesignPatterns
{
    //Abstract Class
    public abstract class AClass
    {
        int Data;
    }
    //Concrete Class One
    public class AConcOne : AClass
    {
        int DataOne;
    }
    //Concrete Class Two
    public class AConcTwo : AClass
    {
        int DataTwo;
    }
    //Abstract Factory
    public interface IFactory
    {
        AClass GetConc();
    }
    //Concrete Factory Class One
    public class FactoryOne : IFactory
    {
        public AClass GetConc()
        {
            return new AConcOne();
        }
    }
    //Concrete Factory Class Two
    public class FactoryTwo : IFactory
    {
        public AClass GetConc()
        {
            return new AConcTwo();
        }
    }
    //Abstract Factory
    public class AbstractFactory
    {
        public IFactory FactoryOne()
        {
            return new FactoryOne();
        }
        public IFactory FactoryTwo()
        {
            return new FactoryTwo();
        }
    }
}
