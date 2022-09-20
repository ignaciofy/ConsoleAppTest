using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Tests
{
    public class SetOfRules
    {
        public int getRuleResult(string[] ops)
        {
            List<int> lops = new List<int>();
            int result = 0;


            for (int i = 0; i < ops.Length; i++)
            {
                switch (ops[i])
                {
                    case "C":
                        if (lops.Count > 1)
                            lops.RemoveAt(i - 1);
                        break;
                    case "D":
                        if (lops.Count > 0)
                            lops.Add(lops[lops.Count - 1] * 2);
                        break;
                    case "+":
                        if (lops.Count > 1)
                            lops.Add(lops[lops.Count - 1] + lops[lops.Count - 2]);
                        break;
                    default:
                        if (int.TryParse(ops[i], out int n))
                            lops.Add(n);
                        break;
                }
            }

            foreach (var num in lops)
            {
                result = result + num;
            }
            return result;
        }
    }
}
