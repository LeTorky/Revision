using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision.DSAlg
{
    internal class BubbleSort
    {
        private int[] Container = new int[] { 5, 3, 4, 2, 1 };
        public void Sort()
        {
            int SortingLength = Container.Length;
            bool SortingFlag = true;
            for (int i = 0; i < Container.Length && SortingFlag; i++)
            {
                SortingFlag = false;
                for (int y = 0; y < SortingLength - 1; y++)
                {
                    if (Container[y] > Container[y + 1])
                    {
                        int TempData = Container[y];
                        Container[y] = Container[y + 1];
                        Container[y + 1] = TempData;
                        SortingFlag = true;
                    }
                }
                SortingLength--;
            }
        }
        public void Print()
        {
            string Values = "";
            for (int i = 0; i < Container.Length; i++)
            {
                Values += Container[i].ToString() + " ";
            }
            Console.WriteLine(Values);
        }
    }
}
