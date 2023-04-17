using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision.DesignPatterns
{
    //Class attributes interface
    interface IComponents
    {
        void GetDetails();
    }

    //Concerete attributes class
    class ComponentsConc : IComponents
    {
        public void GetDetails()
        {
            Console.WriteLine("Concrete Implementation of Components!");
        }
    }

    //Main Class to be built.
    class MainClass
    {
        //List of attributes to be added to.
        public List<IComponents> Components { get; private set; }
        //Constructor
        public MainClass()
        {
            Components = new List<IComponents>();
        }
    }

    //Builder Interface
    interface IBuilder
    {
        //Building Method
        MainClass Build();
    }

    //Builder concrete class
    class BuilderConc:IBuilder
    {
        //Main class instance
        private MainClass MainClass { get; set; }
        //Constructor
        public BuilderConc()
        {
            MainClass = new MainClass();
        }
        //Building Steps
        public void AddData()
        {
            MainClass.Components.Add(new ComponentsConc());
        }
        //Building Method Implementation
        public MainClass Build()
        {
            return MainClass;
        }
    }

}
