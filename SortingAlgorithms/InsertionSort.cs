using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    /// <summary>
    /// Algorithm description: http://www.sorting-algorithms.com/insertion-sort
    /// </summary>
    class InsertionSort : ISorter
    {
        public override void Sort<T>(IList<T> list)
        {
            for (int i = 1; i < list.Count; i++)
                for (int j = i; j > 0 && list[j].CompareTo(list[j - 1]) < 0; j--)
                    Swap(list, j, j - 1);
        }
    }
}
