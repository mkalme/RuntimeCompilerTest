using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuntimeCompiler;

namespace UI {
    class Program {
        private static Compiler Compiler = new Compiler();

        static void Main(string[] args)
        {
            Compiler.Update();
            
            Console.ReadLine();
        }
    }
}
