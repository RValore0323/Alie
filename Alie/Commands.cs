using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Alie
{
    public class Commands
    {
        public static List<Type> list = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => typeof(IAction).IsAssignableFrom(p)).ToList();
        
        public Result CommandCheck(string cmd, string[] postCmd)
        {
            foreach(Type x in list)
            {
                if (x.Name == cmd)
                {
                    var activator = Activator.CreateInstance(x) as IAction;
                    return activator.Run(postCmd);
                }
            }
            
            Console.WriteLine("Unrecognized Command");
            return new Result();
        }
    }
}
