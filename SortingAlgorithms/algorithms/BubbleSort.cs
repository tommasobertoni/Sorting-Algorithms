using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.algorithms
{
    /// <summary>
    /// Algorithm description: http://www.sorting-algorithms.com/bubble-sort
    /// </summary>
    class BubbleSort : ISorter
    {
        public override void Sort<T>(IList<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                bool swapped = false;
                for (int j = list.Count - 1; j > i; j--)
                {
                    if (list[j].CompareTo(list[j - 1]) < 0)
                    {
                        Swap(list, j, j - 1);
                        swapped = true;
                    }
                }

                if (!swapped) break;
            }
        }
    }
}
