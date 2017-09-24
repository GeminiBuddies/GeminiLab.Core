using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiLab.Core.Random {
    public interface IPRNG<out TResult, in TSeed> {
        TResult Next();
        void Initialize(TSeed seed);
    }

    public interface IPRNG<T> : IPRNG<T, T> { }


}
