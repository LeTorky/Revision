using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision.DesignPatterns
{
    //Interface for multiple implementations
    public interface IState
    {
        //first method depending on state to be implemented
        void DoThis();
        //second method depending on state to be implemented
        void DoThat();
    }
    //First State Concrete Class
    public class StateOne : IState
    {
        //State Id to differentiate between other stats
        public string StateId { get; private set; }
        //Constructor
        public StateOne()
        {
            StateId = "State One";
        }
        //First implementation of first method
        public void DoThis()
        {
            Console.WriteLine("Doing This According To State");
        }
        //Second implementation of second method
        public void DoThat()
        {
            Console.WriteLine("Doing That According To State");
        }
    }

    //Second State Concrete Class
    public class StateTwo : IState
    {
        //State Id to differentiate between other stats
        public string StateId { get; private set; }
        //Constructor
        public StateTwo()
        {
            StateId = "State Two";
        }
        //First implementation of first method
        public void DoThis()
        {
            Console.WriteLine("Doing This Differnetly According To State");
        }
        //Second implementation of second method
        public void DoThat()
        {
            Console.WriteLine("Doing That Differnetly According To State");
        }
    }

    //State Context Class that switches states
    public class StateContext
    {
        //State instance
        private IState State;
        //Condition to switch state upon
        private bool Condition;
        //Constructor
        public StateContext()
        {
            State = new StateOne();
            Condition = true;
        }
        //Method to Change State Depending on Condition
        private void ChangeState()
        {
            if (Condition)
                State = new StateOne();
            else
                State = new StateTwo();
        }
        //Invokes Do This of IState and switches condition then changes state
        public void DoThis()
        {
            State.DoThis();
            Condition = Condition == true ? false : true;
            ChangeState();
        }
        //Invokes Do That of IState and switches condition then changes state
        public void DoThat()
        {
            State.DoThat();
            Condition = Condition == true ? false : true;
            ChangeState();
        }
    }
}
