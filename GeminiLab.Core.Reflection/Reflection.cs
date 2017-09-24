using System;
using System.Reflection;
using System.Linq;

namespace GeminiLab.Core.Reflection {
    public static class Reflection {
        public static object InvokeMothod<T>(this T ins, string name, params object[] args) {
            var methodFilter = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            var type = typeof(T);
            var targetMethod = type.GetMethod(name, methodFilter, null, (from i in args select i.GetType()).ToArray(), null) ?? throw new MissingMethodException(type.FullName, name);

            return targetMethod.Invoke(ins, args);
        }

        // What is the best match
        //   
        internal static MethodInfo BestMatch(MethodInfo[] Methods, Type[] args) {
            MethodInfo currBest = null;


            return null;
        }
    }

    public static class StaticInvoker<T> {
        public static object Invoke(string name, params object[] args) {
            var methodFilter = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

            var type = typeof(T);
            var candidates = type.GetMethods(methodFilter).Where(x => x.Name == name);
            var targetMethod = type.GetMethod(name, methodFilter, null, (from i in args select i.GetType()).ToArray(), null) ?? throw new MissingMethodException(type.FullName, name);

            return targetMethod.Invoke(null, args);
        }
    }
}
