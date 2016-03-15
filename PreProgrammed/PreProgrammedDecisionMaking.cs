using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alie;
using System.Reflection;

namespace PreProgrammed
{
    public class PPDM : IAction
    {
        public Result Run(string[] Parameters)
        {
            PreProgrammedDecisionMethods ppdm = new PreProgrammedDecisionMethods();
            Console.WriteLine("Calling Method " + Parameters[0]);
            try
            {
                string param;
                string str = string.Empty;

                try
                {
                    param = Parameters[1];
                }
                catch
                {
                    param = string.Empty;
                }

                if(!(param == string.Empty))
                {
                    str = ppdm.GetType().GetMethod(Parameters[0], BindingFlags.NonPublic | BindingFlags.Instance).Invoke(ppdm, new object[] { param }).ToString();
                }
                else
                {
                    str = ppdm.GetType().GetMethod(Parameters[0], BindingFlags.NonPublic | BindingFlags.Instance).Invoke(ppdm, new object[] { }).ToString();
                }
                
                Console.WriteLine("Method Call Successful");
                Console.WriteLine("");
                Console.WriteLine(str);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Method Call Failed: " + ex.Message);
            }            

            return new Result();
        }

    }

    public class PreProgrammedDecisionMethods
    {
        private string DecideHelloWorld()
        {
            return "Decided Hello World";
        }

        private string AmtrustFridayLunchPlans()
        {
            return "";
        }

        private string AddAmtrustFridayLunchRestraunt(string AddRestraunt)
        {
            return "Added Restraunt " + AddRestraunt;
        }
    }
}
