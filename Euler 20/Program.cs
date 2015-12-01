using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler_20
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] temp = toArray(126);
            //Console.WriteLine(silnia(20));
            int[] temp1 = toArray(12);
            int[] temp2 = toArray(237);
            int[] temp3 = multiplyManually(temp1, temp2);
            Console.ReadKey();
        }

        private static long silnia(int i)
        {
            if (i < 2)
            {
                return 1;
            }
            return i * silnia(i - 1);
        }

        /// <summary>
        /// Zwraca wynik mnożenia jako tablica int
        /// </summary>
        /// <param name="lowerNum">dolna liczba</param>
        /// <param name="upperNum">górna liczba</param>
        /// <returns></returns>
        private static int[] multiplyManually(int[] lowerNum, int[] upperNum)
        {
            List<int> result = new List<int>();
            result.Add(0);

            for (int i = 0; i < lowerNum.Length; i++)
            {
                for (int j = 0; j < upperNum.Length; j++)
                {
                    int partialMultiply = lowerNum[i] * upperNum[j];
                    int[] partialMultiplyArray = toArray(partialMultiply);

                    //częsciowe mnożenie większe od 10, zatem trzeba dziesiątki "podać dalej"
                    if (partialMultiplyArray.Length > 1)
                    {
                        result.Add(0);
                        result[j + 1] = partialMultiplyArray[1];
                    }

                    //zarezerwuj dodatkowe miejsce na cyfrę
                    if (result.Count <= (j + i))
                    {
                        result.Add(0);
                    }

                    if ((result[i + j] + partialMultiplyArray[0]) > 10)
                    {

                    }
                    result[j + i] += partialMultiplyArray[0];
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// Przekształca integera w tablicę int, najmniej znacząca liczba integera ma w tablicy index 0.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private static int[] toArray(int i)
        {
            List<int> digits = new List<int>();

            for (; i != 0; i /= 10)
            {
                digits.Add(i % 10);
            }

            var array = digits.ToArray();
            return array;
        }
    }
}
