﻿using SortingAlgorithms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        private Random _rand = new Random(5);
        private ListSorter _lsort = new ListSorter();
        private IList<string> _list;
        private List<IList> _sortedLists;

        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.init(19);
            Console.WriteLine("\n"); prog.SortUsing("Insertion");
            Console.WriteLine("\n"); prog.SortUsing("Selection");
            Console.WriteLine("\n"); prog.SortUsing("Bubble");
            Console.WriteLine("\n"); prog.SortUsing("Shell");
            Console.WriteLine("\n"); prog.SortUsing("Merge");
            Console.WriteLine("\n"); prog.SortUsing("Heap");
            Console.WriteLine("\n"); prog.SortUsing("Quick");
            Console.WriteLine("\n"); prog.AssertEquals();
            Console.ReadLine();
        }

        public Program()
        {
            _lsort = new ListSorter();
            _sortedLists = new List<IList>();
        }

        private void init(int count = 0)
        {
            if (count < 0) throw new ArgumentOutOfRangeException();
            _sortedLists.Clear();
            _list = GetNewStringsIList(count);
            Console.WriteLine("-----Initial List-----\n");
            Console.WriteLine(ToLinearString(_list));
        }

        private IList<String> GetNewStringsIList(int count)
        {
            var list = new List<String>();
            list.Add("Tty"); //duplicate
            for (int i = 0; i < count - 2; i++)
                list.Add(String.Format("{0}{1}{2}", (char)(_rand.Next(26) + 65),
                                                    (char)(_rand.Next(26) + 97),
                                                    (char)(_rand.Next(26) + 97)));
            list.Add("Tty"); //duplicate

            return list;
        }

        private void AssertEquals()
        {
            if (_sortedLists.Count > 1)
            {
                var headList = _sortedLists[0];
                for (int i = 1; i < _sortedLists.Count; i++)
                {
                    Debug.Assert(headList.Count == _sortedLists[i].Count);
                    for (int j = 0; j < headList.Count; j++)
                    {
                        Debug.Assert(headList[j].Equals(_sortedLists[i][j]));
                    }
                }
                Console.WriteLine("\\Test succeded");
            }
        }

        private string ToLinearString<T>(IList<T> list)
        {
            if (list.Count == 0) return null;

            string linearString = list[0].ToString();
            for (int i = 1; i < list.Count; i++)
                linearString += ", " + list[i].ToString();

            return linearString;
        }

        private void SortUsing(string keyname)
        {
            Console.WriteLine("-----" + keyname + " Sort-----\n");
            List<string> sorted = _list.Select(item => (string)item.Clone()).ToList();

            MethodInfo sortMethod = typeof(ListSorter)
                                .GetMethod(keyname + "Sort")
                                .MakeGenericMethod(new[] { typeof(string) });

            sortMethod.Invoke(_lsort, new object[] { sorted });

            CheckSort(sorted);

            _sortedLists.Add(sorted);
            Console.WriteLine(ToLinearString(sorted));
        }

        private void CheckSort<T>(IList<T> sorted) where T : IComparable
        {
            for (int i = 0; i < sorted.Count - 1; i++)
                if (sorted[i].CompareTo(sorted[i + 1]) > 0)
                    throw new NotSortedException();
        }
    }

    class NotSortedException : Exception { }
}
