using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_Part_2
{
    public class ArrayWithAnyRangeIndex<T>
    {
        private T[] anyArray;

        public ArrayWithAnyRangeIndex(T[] anyArray)
        {
            this.anyArray = anyArray;
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
                if (i >= anyArray.Length)
                    yield break;

                yield return anyArray[i];
            }
        }
    }
}
