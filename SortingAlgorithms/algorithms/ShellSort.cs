using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.algorithms
{
    /// <summary>
    /// Algorithm description: http://www.sorting-algorithms.com/shell-sort
    /// Algorithm visual presentation: https://www.youtube.com/watch?v=M9YCh-ZeC7Y
    /// </summary>
    class ShellSort : ISorter
    {
        public override void Sort<T>(IList<T> list)
        {
            int k = list.Count / 2;
            while (k > 0)
            {
                for (int i = 0; i + k < list.Count; i++)
                {
                    if (list[i + k].CompareTo(list[i]) < 0)
                    {
                        Swap(list, i + k, i);
                        int j = i - k;
                        while (j >= 0)
                        {
                            if (list[j + k].CompareTo(list[j]) < 0) Swap(list, j + k, j);
                            else break;
                            j -= k;
                        }
                    }
                }

                k /= 2;
            }
        }
    }
}
