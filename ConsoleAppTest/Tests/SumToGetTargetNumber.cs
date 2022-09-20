using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Tests
{
    public class SumToGetTargetNumber
    {
        public int[][] chkPair(int[] integers, int targetNumber)
        {
            List<int[]> result = new List<int[]>();
            HashSet<int> s = new HashSet<int>();
            for (int i = 0; i < integers.Length; ++i)
            {
                int temp = targetNumber - integers[i];

                // checking for condition
                if (s.Contains(temp))
                {
                    result.Add(new int[] { integers[i], temp });
                }
                s.Add(integers[i]);
            }

            for (int i = 0;
             i < integers.Length - 2; i++)
            {
                for (int j = i + 1;
                     j < integers.Length - 1; j++)
                {
                    for (int k = j + 1;
                         k < integers.Length; k++)
                    {
                        if (integers[i] + integers[j] + integers[k] == targetNumber)
                        {
                            result.Add( new int[] { integers[i], integers[j], integers[k]});
                        }
                    }
                }
            }
            return result.ToArray();
        }
    }
}
