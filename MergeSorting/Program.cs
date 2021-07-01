using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSorting
{
    class Program
    {
        public static int[] sorting(int[] massive)
        {
            if (massive.Length == 1)
            {
                return massive;
            }
            int middle = massive.Length / 2;
            return merge(sorting(massive.Take(middle).ToArray()), sorting(massive.Skip(middle).ToArray()));
        }
        public static int[] merge(int[] firstPart, int[] secondPart)
        {
            int indexOfFirstPart = 0, indexOfSecondPart = 0;
            int[] merged = new int[firstPart.Length + secondPart.Length];

            for (int i = 0; i < firstPart.Length + secondPart.Length; i++)
            {
                if (indexOfSecondPart < secondPart.Length && indexOfFirstPart < firstPart.Length)
                    if (firstPart[indexOfFirstPart] > secondPart[indexOfSecondPart] && indexOfSecondPart < secondPart.Length)
                        merged[i] = secondPart[indexOfSecondPart++];
                    else
                        merged[i] = firstPart[indexOfFirstPart++];
                else
                if (indexOfSecondPart < secondPart.Length)
                    merged[i] = secondPart[indexOfSecondPart++];
                else
                    merged[i] = firstPart[indexOfFirstPart++];
            }
            return merged;
        }

        static void Main(string[] args)
        {
            int[] massive = new int[] { 8, 10, 4, 5, 1, 6, 8, 2, 5, 9, 0 };
            foreach (int element in sorting(massive))
            {
                Console.WriteLine(element);
            }
            
            Console.ReadKey();
        }
    }
}
