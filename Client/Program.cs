using SortingAlgorithms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        private static Random rand = new Random(5);

        static void Main(string[] args)
        {
            ListSorter lsort = new ListSorter();
            var list = GetNewStringsIList(20);
            List<IList> sortedLists = new List<IList>();

            List<int> tempList = new List<int>(new[] { 3, 6, 9, 2, 5 });
            lsort.SelectionSort(tempList);

            Console.WriteLine("-----Initial List-----\n");
            Console.WriteLine(ToLinearString(list));

            Console.WriteLine("\n\n-----Insertion Sort-----\n");
            var insertionSorted = list.Select(item => (string)item.Clone()).ToList();
            lsort.InsertionSort(insertionSorted);
            sortedLists.Add(insertionSorted);
            Console.WriteLine(ToLinearString(insertionSorted));

            Console.WriteLine("\n\n-----Selection Sort-----\n");
            var selectionSorted = list.Select(item => (string)item.Clone()).ToList();
            lsort.SelectionSort(selectionSorted);
            sortedLists.Add(selectionSorted);
            Console.WriteLine(ToLinearString(selectionSorted));

            if (sortedLists.Count > 1)
            {
                var headList = sortedLists[0];
                for (int i = 1; i < sortedLists.Count; i++)
                {
                    Debug.Assert(headList.Count == sortedLists[i].Count);
                    for (int j = 0; j < headList.Count; j++)
                    {
                        Debug.Assert(headList[j].Equals(sortedLists[i][j]));
                    }
                }
                Console.WriteLine("\n\n\n\\Test succeded");
            }

            Console.ReadLine();
        }

        private static string ToLinearString<T>(IList<T> list)
        {
            if (list.Count == 0) return null;

            string linearString = list[0].ToString();
            for (int i = 1; i < list.Count; i++)
                linearString += ", " + list[i].ToString();

            return linearString;
        }

        private static IList<String> GetNewStringsIList(int count)
        {
            var list = new List<String>();
            for (int i = 0; i < count; i++)
                list.Add(String.Format("{0}{1}{2}", (char)(rand.Next(26) + 65),
                                                    (char)(rand.Next(26) + 97),
                                                    (char)(rand.Next(26) + 97)));

            return list;
        }
    }
}
