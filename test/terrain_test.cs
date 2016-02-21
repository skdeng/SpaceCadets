using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacecadets
{
    class Test
    {
        public static void Main()
        {
            int w, h;
            Console.Write("Input the width: ");
            w = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input the height: ");
            h = Convert.ToInt32(Console.ReadLine());
            int seed;
            Console.Write("Input the seed: ");
            seed = Convert.ToInt32(Console.ReadLine());

            Terrain terrain = new Terrain(seed);
            terrain.generate(w, h);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                    Console.Write(terrain.sample(i, j) + "   ");
                Console.Write('\n');
            }
        }
    }
}
