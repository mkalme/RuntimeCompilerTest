using System;
using System.Reflection;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace RuntimeCompiler
{
    public class Compiler {

        public Compiler() { 
        
        }

        public void Update() {
            //string[] lines = File.ReadAllLines(@"Assets\ClassTextData.json");
            //string code = GetCode(String.Join("", lines));
            string code = String.Join("\n", File.ReadAllLines(@"Assets\Code.txt"));

            Assembly assembly = AssemblyHelper.BuildAssembly(code);

            object instance = assembly.CreateInstance("RuntimeProcessor.Processor");
            Type type = instance.GetType();

            MethodInfo method = type.GetMethod("Update");
            for (int i = 0; i < 100; i++) {
                Console.WriteLine((float)method.Invoke(instance, new object[] { }));

                System.Threading.Thread.Sleep(500);
            }
        }

        private static string GetCode(string json) {
            JObject obj = JObject.Parse(json);

            StringBuilder code = new StringBuilder();

            code.Append(JSonHelper.JoinJArray("\n", (JArray)obj["Header"]));
            code.Append("\n");
            code.Append(JSonHelper.JoinJArray("\n", (JArray)obj["Body"]));
            code.Append("\n");
            code.Append(JSonHelper.JoinJArray("\n", (JArray)obj["End"]));

            return code.ToString();
        }
    }
}
