using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeMaxPath
    {
    class Program
        {
        static void Main (string[] args)
            {
            Pyramid pyramid = PyramidBuilder.BuildFromFile("Data.dat");

            Console.WriteLine(new PyramidResolver(pyramid).ResolveMax());
            Console.ReadKey();
            }
        }
    }
