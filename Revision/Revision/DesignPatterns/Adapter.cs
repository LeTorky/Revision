using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision.DesignPatterns
{
    //Service Class does work in an un compatible way
    public class Service
    {
        public void DoWork()
        {
            Console.WriteLine("I Do Work In a Specific Way!");
        }
    }
    //Client Class needs Service to output in a different way
    public class Client
    {
        private IAdapter Adapter;
        public Client(IAdapter SetAdapter)
        {
            Adapter = SetAdapter;
        }
        public void DoWork()
        {
            Adapter.DoWork();
        }
    }
    //Adapter Interface
    public interface IAdapter
    {
        //Method that changes service work in a compatible format
        void DoWork();
    }
    //Adapter Concrete class that outputs in a specific format
    public class Adapter : IAdapter
    {
        //Private member of the service
        private Service Service;
        //Constructor
        public Adapter()
        {
            Service = new Service();
        }
        //Changes format of output
        public void DoWork()
        {
            Service.DoWork();
            Console.WriteLine("Ive Changed The Outcome To Match The Client");
        }
    }
}
