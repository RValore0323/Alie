using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alie;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.CSharp;
using System.Reflection;
using System.CodeDom;

namespace Commands
{
    public class CreateAssembly : IAction
    {
        public Result Run(string[] Parameters)
        {
            Console.WriteLine("Generating Code For " + Parameters[0]);

            string Code = string.Empty;
            switch (Parameters[0])
            {
                case "HelloWorld":
                    Code = HelloWorld();
                    break;
                default:
                    break;
            }

            CreateAssemblyFunctions.Compile(Code);
            
            //Console.WriteLine("CreatingAssembly");
            //CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            //ICodeCompiler icc = codeProvider.CreateCompiler();
            //System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            //parameters.GenerateExecutable = false;
            //parameters.OutputAssembly = "AutoGen.dll";
            //CompilerResults results = icc.CompileAssemblyFromSource(parameters, Code);
            //Console.WriteLine("CallingCommands");
            //Program.CallCommands($"ImportExternalCommands {results.CompiledAssembly.Location}");

            //var assembly = results.CompiledAssembly.Location;
            //Alie.Commands.list.AddRange(assembly.GetTypes().Where(p => typeof(IAction).IsAssignableFrom(p)).ToList());
            //Console.WriteLine("Import Of " + Parameters[0] + " Successful");

            return new Result();
        }

        public string HelloWorld()
        {
            string Code = string.Empty;
            Code = "using System; using System.Collections.Generic; using System.Text; using Alie; using System.Threading.Tasks; ";
            Code += "namespace Commands { public class AutoGen : IAction { ";

            Code += "public Result Run(string[] Parameters) { ";

            Code += "Console.WriteLine(\"Hello World!\"); return new Result();";

            Code += " } ";

            Code += " } }";
            Console.WriteLine("Code Generation Successful");
            return Code;
        }
    }

    public static class CreateAssemblyFunctions
    {
        public static void Compile(string source)
        {
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            CompilerParameters param = new CompilerParameters();
            param.GenerateExecutable = false;
            param.IncludeDebugInformation = false;
            param.GenerateInMemory = true;
            param.ReferencedAssemblies.Add(Alie.Program.ass.Location);
            ICodeCompiler cc = codeProvider.CreateCompiler();
            CompilerResults cr = cc.CompileAssemblyFromSource(param, source);
            StringCollection output = cr.Output;
            if (cr.Errors.Count != 0)
            {
                System.Console.WriteLine("Error invoking scripts.");
                CompilerErrorCollection es = cr.Errors;
                foreach (CompilerError s in es)
                    System.Console.WriteLine(s.ErrorText);
            }
            else
            {
                Alie.Commands.list.AddRange(cr.CompiledAssembly.GetTypes().Where(p => typeof(IAction).IsAssignableFrom(p)).ToList());
            }
        }
    }
}
