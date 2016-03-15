using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Alie
{
    class ImportExternalCommands : IAction
    {
        public Result Run(string[] Parameters)
        {
            Console.WriteLine("Importing");
            try
            {
                var assembly = Assembly.LoadFrom(Parameters[0]);
                Commands.list.AddRange(assembly.GetTypes().Where(p => typeof(IAction).IsAssignableFrom(p)).ToList());
                Console.WriteLine("Import Of " + Parameters[0] + " Successful");
                return new Result();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Import Failed");
                return new Result { Error = ex.Message };
            }
        }

    }
}
