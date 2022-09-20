using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Tests
{
    internal class DiskSpace
    {
        public static int segment(int x, List<int> space)
        {
            var chunkNum = 1;
            var s = new Stack<int>();
            s.Push(0);

            for (int i = 1; i < space.Count; i++)
            {
                // first chunk
                if (i < x)
                {
                    if (space[i] < space[s.Peek()])
                    {
                        s.Pop();
                        s.Push(i);
                    }
                }
                // other chunks
                else
                {
                    // if found minimum is member of current chunk we just need to compare current number with it
                    var peek = s.Peek();
                    if (peek >= chunkNum)
                    {
                        s.Push(space[i] < space[peek] ? i : peek);
                    }
                    // we have to loop through current chunk to find minimum number
                    else
                    {
                        s.Push(i);

                        var j = chunkNum;
                        var count = 0;
                        while (count++ < x)
                        {
                            if (space[j] < space[s.Peek()])
                            {
                                s.Pop();
                                s.Push(j);
                            }
                            j++;
                        }
                    }
                    // we are ready to go to next chunk
                    chunkNum++;
                }
            }

            return s.Select(c => space[c]).Max();
        }

    }
}

