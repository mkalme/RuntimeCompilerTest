using System;
using System.Text;
using Newtonsoft.Json.Linq;

namespace RuntimeCompiler {
    static class JSonHelper {
        public static string JoinJArray(string seperator, JArray array) {
            StringBuilder output = new StringBuilder();

            output.Append(String.Join(seperator, array.Values()));

            return output.ToString();
        }
    }
}
