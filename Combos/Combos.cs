using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combos
{
    internal class Combos
    {
        public static List<string> AllCombos;

        public static int K;
        public static int N;
        private static int[] buffer;

        public static void Init()
        {
            AllCombos = new List<string>();
            buffer = new int[K];
            MakeCombos(0, 0);
            ShowCombos();
        }

        private static void ShowCombos()
        {
            foreach (var combo in AllCombos)
                Console.WriteLine(combo);

            Console.WriteLine($"Total combos: {AllCombos.Count}");
        }

        private static void MakeCombos(int idx, int begin)
        {
            for (int i = begin; i < N; i++)
            {
                buffer[idx] = i;
                if (idx + 1 < K) MakeCombos(idx + 1, buffer[idx] + 1);
                else AllCombos.Add(string.Join(" ", buffer));
            }
        }
    }
}
