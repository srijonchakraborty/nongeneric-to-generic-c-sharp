using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonGenericToGenericCSharpExample
{
    internal class NonGenericToGenericCSharp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("T2");
            NonGenericToGenericCSharpExample.NonGeneric.Service.CallNonGenricClass();
            NonGenericToGenericCSharpExample.Generic.Service.CallGenricClass();
        }

    }
}
