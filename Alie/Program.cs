using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Alie
{
    public class Program
    {
        public static Assembly ass = Assembly.GetEntryAssembly();

        static Commands commands = new Commands();

        static void Main(string[] args)
        {
            InitializeAli();
        }

        static void InitializeAli()
        {
            Console.WriteLine("ImportExternalCommands Commands.dll");
            string[] z = new string[2];
            z[0] = "ImportExternalCommands";
            z[1] = @"..\..\..\Commands\bin\Debug\Commands.dll";
            Result a = commands.CommandCheck(z[0], z.RemoveAt(0));
            if(!string.IsNullOrEmpty(a.Error))
            {
                Console.WriteLine(a.Error);
            }

            Console.WriteLine("");

            Console.WriteLine("ImportExternalCommands PreProgrammed.dll");
            z[0] = "ImportExternalCommands";
            z[1] = @"..\..\..\PreProgrammed\bin\Debug\PreProgrammed.dll";
            Result b = commands.CommandCheck(z[0], z.RemoveAt(0));
            if (!string.IsNullOrEmpty(a.Error))
            {
                Console.WriteLine(a.Error);
            }

            Console.WriteLine("");
            
            string Greeting = RetrieveGreeting();

            Console.WriteLine(Greeting);

            Console.WriteLine("");

            bool Switch = true;
            while (Switch)
            {

                string Response = Console.ReadLine();

                Result result = CallCommands(Response);

                Console.WriteLine("");

                if (result.KillAlie)
                {
                    Switch = false;
                }
            }
        }

        static string RetrieveGreeting()
        {
            string Time;
            if (DateTime.Now.Hour < 12)
            {
                Time = "Good Morning.";
            }
            else if (DateTime.Now.Hour < 17)
            {
                Time = "Good Afternoon.";
            }
            else
            {
                Time = "Good Evening.";
            }

            return Time + " What Can I Do For You?";
        }

        public static Result CallCommands(string Response)
        {
            string[] cmds = Response.Split(' ');

            Result result = commands.CommandCheck(cmds[0], cmds.RemoveAt(0));
            return result;
            Console.WriteLine("");
        }
        
    }

    static class Ultilies
    {
        public static T[] RemoveAt<T>(this T[] source, int index)
        {
            T[] dest = new T[source.Length - 1];
            if (index > 0)
                Array.Copy(source, 0, dest, 0, index);

            if (index < source.Length - 1)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

            return dest;
        }
    }
}
