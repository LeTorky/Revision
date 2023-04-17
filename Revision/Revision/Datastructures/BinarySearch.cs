using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision.DSAlg
{
    internal class BinarySearch
    {
        private int[] Container = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public int Search(int Value)
        {
            return Search(0, Container.Length - 1, Value);
        }
        private int Search(int StartIndex, int EndIndex, int Value)
        {
            int retval = 0;
            int MiddleIndex = (StartIndex + EndIndex) / 2;
            if (MiddleIndex > EndIndex || MiddleIndex < StartIndex)
                throw new Exception("Element doesnt exist within context!");
            int MiddleValue = Container[MiddleIndex];
            if (MiddleValue == Value)
                retval = MiddleIndex;
            else
                if (Value > MiddleValue)
                retval = Search(MiddleIndex + 1, EndIndex, Value);
            else
                retval = Search(StartIndex, MiddleIndex - 1, Value);
            return retval;
        }
    }
}
