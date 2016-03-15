using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alie
{
    class KillAlie : IAction
    {
        public Result Run(string[] Parameters)
        {
            return new Result
            {
                KillAlie = true
            };

        }
    }
}
