using SortingAlgorithms;
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

        public static class ShellSorter
        {
            public static void Sort<T>(List<T> list) where T : IComparable
            {
                int n = list.Count;
                int[] incs = { 1, 3, 7, 21, 48, 112, 336, 861, 1968, 4592, 13776, 33936, 86961, 198768, 463792, 1391376, 3402672, 8382192, 21479367, 49095696, 114556624, 343669872, 52913488, 2085837936 };
                for (int l = incs.Length / incs[0]; l > 0; )
                {
                    int m = incs[--l];
                    for (int i = m; i < n; ++i)
                    {
                        int j = i - m;
                        if (list[i].CompareTo(list[j]) < 0)
                        {
                            T tempItem = list[i];
                            do
                            {
                                list[j + m] = list[j];
                                j -= m;
                            } while ((j >= 0) && (tempItem.CompareTo(list[j]) < 0));
                            list[j + m] = tempItem;
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.init();
            Console.WriteLine("\n"); prog.SortUsing("Insertion");
            Console.WriteLine("\n"); prog.SortUsing("Selection");
            Console.WriteLine("\n"); prog.SortUsing("Bubble");
            Console.WriteLine("\n"); prog.SortUsing("Shell");
            Console.WriteLine("\n"); prog.AssertEquals();
        }

        public Program()
        {
            _lsort = new ListSorter();
            _sortedLists = new List<IList>();
        }

        private void init()
        {
            _list = GetNewStringsIList(19);
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

            Console.ReadLine();
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

            if (keyname.Equals("Shell") && false)
            {
                ShellSorter.Sort(new List<int>(new int[] {3, 6, 9, 2, 5}));
                ShellSorter.Sort(sorted);
            }
            else
            {
                MethodInfo sortMethod = typeof(ListSorter)
                                   .GetMethod(keyname + "Sort")
                                   .MakeGenericMethod(new[] { typeof(string) });

                sortMethod.Invoke(_lsort, new object[] { sorted });
            }

            _sortedLists.Add(sorted);
            Console.WriteLine(ToLinearString(sorted));
        }
    }
}
