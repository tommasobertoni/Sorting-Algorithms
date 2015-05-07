using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.algorithms
{
    abstract class ISorter
    {
        abstract public void Sort<T>(IList<T> list) where T : IComparable;

        protected void Swap<T>(IList<T> list, int index1, int index2)
        {
            if (index1 == index2) return;
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
