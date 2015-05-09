using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.algorithms
{
    /// <summary>
    /// Algorithm description: http://www.sorting-algorithms.com/quick-sort
    /// </summary>
    class QuickSort : ISorter
    {
        private Random _rand;

        public QuickSort()
        {
            _rand = new Random();
        }

        public QuickSort(int seed)
        {
            _rand = new Random(seed);
        }

        public override void Sort<T>(IList<T> list)
        {
            qsort(list, 0, list.Count - 1);
        }

        private void qsort<T>(IList<T> list, int start, int end) where T : IComparable
        {
            if (end - start < 1) return;
            int pivot = _rand.Next(end - start + 1) + start;
            Swap(list, start, pivot);

            int j = start;
            for (int i = start + 1; i <= end; i++)
                if (list[i].CompareTo(list[start]) < 0)
                    Swap(list, ++j, i);

            Swap(list, start, j);

            if (j > start) qsort(list, start, j - 1);
            if (j + 1 < end) qsort(list, j + 1, end);
        }
    }
}
