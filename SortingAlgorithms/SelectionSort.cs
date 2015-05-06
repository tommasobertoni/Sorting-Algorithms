using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    /// <summary>
    /// Algorithm description: http://www.sorting-algorithms.com/selection-sort
    /// </summary>
    class SelectionSort : ISorter
    {
        public override void Sort<T>(IList<T> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < list.Count; j++)
                    if (list[j].CompareTo(list[min]) < 0)
                        min = j;

                Swap(list, i, min);
            }
        }
    }
}
