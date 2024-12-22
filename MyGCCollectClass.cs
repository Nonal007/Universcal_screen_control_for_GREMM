using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universcal_screen_control_for_GREMM
{
    internal class MyGCCollectClass
    {
        private const int maxGarbage = 1000;

        static void Main1()
        {
            // Put some objects in memory.
            MyGCCollectClass.MakeSomeGarbage();
            Console.WriteLine("Memory used before collection:       {0:N0}",
                              GC.GetTotalMemory(false));

            // Collect all generations of memory.
            GC.Collect();
            Console.WriteLine("Memory used after full collection:   {0:N0}",
                              GC.GetTotalMemory(true));
        }

        static void MakeSomeGarbage()
        {
            Version vt;

            // Create objects and release them to fill up memory with unused objects.
            for (int i = 0; i < maxGarbage; i++)
            {
                vt = new Version();
            }
        }
    }
}
