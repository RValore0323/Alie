using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alie
{
    public interface IAction
    {
        Result Run(string[] Parameters);
    }

    public class Result
    {
        public bool KillAlie;
        public string Error;
    }


}
