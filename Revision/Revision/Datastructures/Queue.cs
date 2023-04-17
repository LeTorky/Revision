using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision.DSAlg
{
    internal class Queue
    {
        //Array of Data
        private int[] Container;

        //Length of Array
        int Length;

        //Full Flag
        bool Full = false;

        //Empty Flag
        bool Empty = true;

        //Top and Bottom of Queue
        public int ToQ = 0;
        public int BoQ = 0;

        //Constructor (takes Size to construct Array)
        public Queue(int Size)
        {
            Container = new int[Size];
            Length = Size;
        }

        //Pop method
        public int Pop()
        {
            if (Empty == true)
            {
                throw new Exception("No entries!");
            }
            int retval = Container[(BoQ + 1) % Length];
            BoQ++;
            Full = false;
            if (BoQ % Length == ToQ % Length)
                Empty = true;
            return retval;
        }

        //Push method
        public void Push(int Data)
        {
            if (Full == true)
            {
                throw new Exception("Queue is full!");
            }
            Container[(ToQ + 1) % Length] = Data;
            ToQ++;
            Empty = false;
            if (BoQ % Length == ToQ % Length)
                Full = true;
        }
    }
}
