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
                else
                {
                    string comboAsString = string.Empty;
                    foreach(var bufferAsString in buffer)
                        comboAsString += bufferAsString;

                    AllCombos.Add(comboAsString);
                }
            }
        }
    }
}

// Мы заходим на первую итерацию цикла
// Устанавливаем в первую позицию значение I, чтобы на первой позиции получить все возможные цифры
// Далее проверяем, что позиции для размещения еще не заняты
// И если это так, то вызываем вновь данный метод, но уже начнем заполнение со следующей позиции,
// которое сформируем как текущее значение заполненной позиции буфера + 1, а idx будет служить ячейкой для 
// индекса(позиции в строке), его просто повышаем, в будущем будет проверять, что мы не вышли за предел
// доступных размещений.
// Вызвав рекурсию входим, цикл уже запускам не с 0 позиции, а с последующего значения из перебора
// (если было 1, 2 или 3, то станет 2, 3 или 4 соответственно)
// Опять запускаем цикл на все уже оставшиеся цифры до введенной в качестве N.
// В следующую позицию буфера записываем следующую цифру, опять проверяем, что не вышли за пределы позиций
// И так повторяем до конца длины размещений.
// Как только достигли конца размещений - рекурсия завершится, наш buffer формировался на всем ее протяжении
// Соответственно мы можем теперь получить из него комбинацию и записать в массив.
// Если идти по основному циклу дальше, то начнется формирование второй комбинации
// i = 1, следовательно теперь [0] индекс начнется с 1, а продолжится i+1

/*
 * N = 3 K = 2
    MakeCombos(0,0)
        i = 0 < 3
            buffer = "0"
            0 + 1 < 2 
                MakeCombos(1, 1)
                i = 1 < 3
                buffer = "01"
                2 < 2 -- return 01
        i = 1 < 3
            buffer = "1"
            0 + 1 < 2 
                MakeCombos(1, 2)
                i = 1 < 3
                buffer = "12"
                2 < 2 -- return 12
        i = 2 < 3
            buffer = "2"
            0 + 1 < 2
                MakeCombos(1, 3)
                i = 1 < 3
        i = 3 < 3 --- stop, три позиция пройдены
*/