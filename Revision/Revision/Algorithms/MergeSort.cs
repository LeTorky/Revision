using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision.Algorithms
{
    public static class MergeSort
    {
        private static void Merge(int[] Array, int FromIndex, int ToIndex)
        {
            int[] EditArray = (int[]) Array.Clone();
            int MiddleIndex = (ToIndex + FromIndex) / 2;
            int CurrentIndex = FromIndex;
            int CurrentLeft = FromIndex;
            int CurrentRight = MiddleIndex + 1;
            while (CurrentLeft <= MiddleIndex && CurrentRight <= ToIndex)
            {
                if (Array[CurrentLeft] < Array[CurrentRight])
                {
                    EditArray[CurrentIndex++] = Array[CurrentLeft++];
                }
                else
                {
                    EditArray[CurrentIndex++] = Array[CurrentRight++];
                }
            }
            while (CurrentLeft <= MiddleIndex)
            {
                EditArray[CurrentIndex++] = Array[CurrentLeft++];
            }
            while (CurrentRight <= ToIndex)
            {
                EditArray[CurrentIndex++] = Array[CurrentRight++];
            }
            for (int i = 0; i < Array.Length; i++)
            {
                Array[i] = EditArray[i];
            }
        }
        private static void Sort(int[] Array, int FromIndex, int ToIndex)
        {
            if (ToIndex > FromIndex)
            {
                Sort(Array, FromIndex, (FromIndex + ToIndex) / 2);
                Sort(Array, ((FromIndex + ToIndex) / 2) + 1, ToIndex);
                Merge(Array, FromIndex, ToIndex);
            }
        }
        public static int[] Invoke(int[] Array, int FromIndex, int ToIndex)
        {
            if (FromIndex >= ToIndex || ToIndex > Array.Length || Array.Length < FromIndex)
                throw new ArgumentException("Array out of bounds or indices are illogical");
            Sort(Array, FromIndex, ToIndex);
            return Array;
        }
    }
}
