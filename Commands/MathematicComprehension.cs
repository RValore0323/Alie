using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alie;

namespace Commands
{
    public class Calculate : IAction
    {
        public Result Run(string[] Parameters)
        {
            int i = 0;
            List<string> completeEquation = new List<string>();
            
            foreach (char s in Parameters[0]) {
                try
                {
                    int a = Convert.ToInt32(s.ToString());
                    try
                    {
                        completeEquation[i] += s.ToString();
                    }
                    catch
                    {
                        completeEquation.Add(s.ToString());
                    }
                }
                catch
                {
                    i += 1;
                    completeEquation.Add(s.ToString());
                    i += 1;
                }
            }

            Console.WriteLine("Attempling To Equate " + completeEquation[0] + " With Operaterator " + completeEquation[1] + " Against Number " + completeEquation[2]);

            return new Result();
        }
    }
}
