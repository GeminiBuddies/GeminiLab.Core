using System;

namespace GeminiLab.Core {
    public static class ExtensionUtil {
        public static T CastTo<T>(this object source) => (T)source;
    }
}
