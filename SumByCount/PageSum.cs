using System;
using System.Linq;

namespace SumByCount
{
    public class PageSum
    {
        public int[] SumByN(int count, params int[] ints)
        {
            int lessCount = ints.Count() % count;
            int resultCount = ints.Count() / count;
            if (lessCount != 0)
            {
                ints = ints.Concat(Enumerable.Repeat(0, count - lessCount)).ToArray();
                resultCount = ints.Count() / count;
            }

            int numbersIndex = 0;
            int resultIndex = 0;
            int singlePageSum = 0;
            int[] result = new int[resultCount];
            foreach (var item in ints)
            {
                singlePageSum = singlePageSum + ints[numbersIndex];
                if (numbersIndex % count == count - 1)
                {
                    result[resultIndex] = singlePageSum;
                    resultIndex++;
                    singlePageSum = 0;
                }
                numbersIndex++;
            }
            return result;
        }
    }
}
