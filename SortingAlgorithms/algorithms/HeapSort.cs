using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.algorithms
{
    class HeapSort : ISorter
    {
        public override void Sort<T>(IList<T> list)
        {
            //heapify
            for (int i = list.Count / 2; i > 0; i--)
                Sink(list, i - 1, list.Count - 1);

            IList<T> sorted = new List<T>(list.Count);

            //sortdown
            for (int i = 0; i < list.Count; i++)
            {
                sorted.Add(list[0]);
                list[0] = list[list.Count - i - 1];
                Sink(list, 0, list.Count - i - 1);
            }

            list.Clear();
            foreach (T elem in sorted) list.Add(elem);
        }

        private void Sink<T>(IList<T> list, int i, int depth) where T : IComparable
        {
            int lc = i * 2 + 1;
            if (lc > depth) return;
            int rc = lc + 1;
            int mc = (rc > depth) ? lc : (list[lc].CompareTo(list[rc]) < 0) ? lc : rc;
            if (list[i].CompareTo(list[mc]) > 0)
            {
                Swap(list, i, mc);
                Sink(list, mc, depth);
            }
        }
    }
}
