using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.algorithms
{
    /// <summary>
    /// Algorithm description: http://www.sorting-algorithms.com/merge-sort
    /// </summary>
    class MergeSort : ISorter
    {
        public override void Sort<T>(IList<T> list)
        {
            if (list.Count < 2) return;
            else if (list.Count == 2) 
            {
                if (list[1].CompareTo(list[0]) < 0)
                    Swap(list, 0, 1);
            }
            else sort(list);
        }

        private void sort<T>(IList<T> list) where T : IComparable
        {
            for (int i = 0; i < list.Count - 1; i += 2) //sort pairs
            {
                if (list[i + 1].CompareTo(list[i]) < 0)
                    Swap(list, i, i + 1);
            }

            //merge by grups length 4n
            int h = 4, k, n;
            do
            {
                k = 0;
                n = h / 2;
                do
                {
                    mergeInto(list, k, list.Skip(k).Take(n).ToList(), list.Skip(k + n).Take(n).ToList());
                    k += h;
                } while (k < list.Count);
                h *= 2;

            } while (h <= list.Count);

            n = h / 2;
            mergeInto(list, 0, list.Take(n).ToList(), list.Skip(n).Take(n).ToList());
        }

        private void mergeInto<T>(IList<T> list, int start, IList<T> list1, IList<T> list2) where T : IComparable
        {
            int position = start;
            int i = 0, j = 0;
            while (i < list1.Count && j < list2.Count)
            {
                T temp;
                if (list2[j].CompareTo(list1[i]) < 0) temp = list2[j++];
                else temp = list1[i++];
                list[position++] = temp;
            }

            while (i < list1.Count) list[position++] = list1[i++];
            while (j < list2.Count) list[position++] = list2[j++];
        }
    }
}
