using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Revision.DesignPatterns
{
    //Second Dependancy Interface
    interface IDepTwo
    {
        //Do work method
        void DoWork();
    }

    //Second Dependancy Concrete Class
    class DepTwo : IDepTwo
    {
        //Constructor
        public DepTwo()
        {
            Console.WriteLine("Dependancy Two Constructed!");
        }
        //Do work Implementation
        public void DoWork()
        {
            Console.WriteLine("Dependancy Two Invoked!");
        }
    }

    //First Dependancy Interface
    interface IDepOne 
    {
        //Do work implementation
        void DoWork();
    }

    //First Dependancy Concrete Class
    class DepOne : IDepOne
    {
        //Second Dependancy Instance
        private IDepTwo DepTwo { get; set; }
        //Constructor with Second Dependancy
        public DepOne(IDepTwo depTwo)
        {
            Console.WriteLine("Dependancy One Constructed!");
            this.DepTwo = depTwo;
        }
        //Do work method Implementation
        public void DoWork()
        {
            //Depends on Second Dependancy DoWork
            DepTwo.DoWork();
            Console.WriteLine("Dependancy One Invoked!");
        }
    }

    //Dependant Interface
    interface IDepandant 
    { 
        //Do work method
        void DoWork();
    }

    //Dependant Concrete Class
    class Dependant : IDepandant
    {
        //First Dependancy Instance
        private IDepOne DepOne { get; set; }
        //Constructor with first dependancy
        public Dependant(IDepOne depOne)
        {
            this.DepOne = depOne;
        }
        //Do work implementation
        public void DoWork()
        {
            //Depends on first dependancy
            DepOne.DoWork();
        }
    }

    //DI Container class with generics to define the first object being built
    internal class DIContainer<I,C> where C : I
    {
        //Dictionary holds interfaces with their Concrete correspondants
        private readonly Dictionary<Type, Type> Types = new Dictionary<Type, Type>();
        //Method to link Concrete Class to its Interface
        public void AddDependancy<IClass, Class>() where Class : IClass
        {
            Types[typeof(IClass)] = typeof(Class);
        }
        //Method to return constructed class
        public I Build()
        {
            return (I)Construct(typeof(I));
        }
        //Recursive private method that constructs object with dependancies
        private Object Construct(Type type)
        {
            //Gets Concrete class from Dictionary
            Type ConcreteType = Types[type];
            //Gets Constructor
            ConstructorInfo DefaultConstructor = ConcreteType.GetConstructors()[0];
            //Gets parameters in the constructor
            List<ParameterInfo> ConstructorParams = DefaultConstructor.GetParameters().ToList();
            //Reinvokes the same function for each parameter
            object[] ConstructedParams = ConstructorParams.Select(P => Construct(P.ParameterType)).ToArray();
            //Returns constructed object
            return DefaultConstructor.Invoke(ConstructedParams);
        }
        //Constructor
        public DIContainer()
        {
            //Adds the generics interface and concrete class to dictionary
            AddDependancy<I, C>();
        }
    }
}
