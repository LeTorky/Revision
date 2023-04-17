using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision.DSAlg
{
    public class StackViaArray
    {
        //Index of Top of Stack (Last Item Inserted, used in Pushing and Popping)
        public int ToS { get; private set; }
        //Array holding Data.
        private int[] Container;

        //Constructor (Sets size of Array)
        public StackViaArray(int Size)
        {
            Container = new int[Size];
        }

        //Push Method (Inserts data into Array)
        public void Push(int Data)
        {
            if(ToS >= Container.Length - 1)
                throw new Exception("Exceeded Stack Limit!");

            Container[ToS++] = Data;
        }

        //Pop Method (Pops data from Array)
        public int Pop()
        {
            if (ToS == 0)
                throw new Exception("Stack Is Empty!");
            return Container[--ToS];
        }

        //Peek Method (Checks Data without Changing Indexer) 
        public int Peek()
        {
            if (ToS == 0)
                throw new Exception("Stack Is Empty!");
            return Container[ToS-1];
        }
    }
}
