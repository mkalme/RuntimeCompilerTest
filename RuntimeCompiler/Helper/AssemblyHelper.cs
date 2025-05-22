using System;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;
using System.Text;

namespace RuntimeCompiler {
    static class AssemblyHelper {
        public static Assembly BuildAssembly(string code) {
            CSharpCodeProvider provider = new CSharpCodeProvider();
            ICodeCompiler compiler = provider.CreateCompiler();

            CompilerParameters compilerparams = new CompilerParameters();
            compilerparams.GenerateExecutable = false;
            compilerparams.GenerateInMemory = true;

            CompilerResults results = compiler.CompileAssemblyFromSource(compilerparams, code);

            if (results.Errors.HasErrors) {
                StringBuilder errors = new StringBuilder("Compiler Errors :\r\n");
                foreach (CompilerError error in results.Errors) {
                    errors.AppendFormat("Line {0},{1}\t: {2}\n",
                           error.Line, error.Column, error.ErrorText);
                }
                throw new Exception(errors.ToString());
            } else {
                return results.CompiledAssembly;
            }
        }
    }
}
