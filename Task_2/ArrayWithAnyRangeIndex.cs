using System;
using System.Collections;

namespace Task_2
{
    class ArrayWithAnyRangeIndex
    {
        private int[] AnyArray;
        public ArrayWithAnyRangeIndex()
        {
            AnyArray = new int[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 84 };
        }

        public IEnumerable GetArrayBySetRange(int start, int end)
        {
            try
            {
                if (start > end)
                    throw new ArgumentException(" \"Start can not be less then End\" ");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            for (int i = start; i < end; i++)
            {
                if (i >= AnyArray.Length)
                    yield break;

                yield return AnyArray[i];
            }
        }
    }
}
