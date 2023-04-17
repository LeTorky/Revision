using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision
{
    public class Solution
    {
            public static int RemoveDuplicates(int[] nums)
            {
                int Duplicate = 0;
                int i = 0;
                int j = 0;
                bool Flag = false;
                while (i < nums.Length)
                {
                    if (!Flag)
                    {
                        if (nums[i] == nums[i + 1])
                        {
                            j = i + 1;
                            Flag = true;
                            Duplicate = nums[i];
                        }
                    }
                    if (j != 0 && nums[i] != Duplicate)
                    {
                        int Temp = Duplicate;
                        if (i != nums.Length-1 && nums[i] == nums[i + 1])
                        {
                            Duplicate = nums[i];
                        }
                        nums[j++] = nums[i];
                        nums[i] = Duplicate;
                    }
                    ++i;
                }
                j = j == 0 ? nums.Length : j;
                return j;
            }
        public static void Main()
        {
            RemoveDuplicates(new int[] { 1, 1, 2 });
        }
    }
}
