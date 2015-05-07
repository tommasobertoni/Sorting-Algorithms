﻿using SortingAlgorithms.algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class ListSorter
    {
        private ISorter _insertionSorter,
                        _selectionSorter,
                        _bubbleSorter,
                        _shellSorter;

        public void InsertionSort<T>(IList<T> list) where T : IComparable
        {
            if (_insertionSorter == null) _insertionSorter = new InsertionSort();
            _insertionSorter.Sort(list);
        }

        public void SelectionSort<T>(IList<T> list) where T : IComparable
        {
            if (_selectionSorter == null) _selectionSorter = new SelectionSort();
            _selectionSorter.Sort(list);
        }

        public void BubbleSort<T>(IList<T> list) where T : IComparable
        {
            if (_bubbleSorter == null) _bubbleSorter = new BubbleSort();
            _bubbleSorter.Sort(list);
        }

        public void ShellSort<T>(IList<T> list) where T : IComparable
        {
            if (_shellSorter == null) _shellSorter = new ShellSort();
            _shellSorter.Sort(list);
        }
    }
}
