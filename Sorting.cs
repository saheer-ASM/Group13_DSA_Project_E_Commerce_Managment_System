using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    // Contains comparison methods and sorting algorithms.
    public static class Sorting
    {
        // Comparison method for sorting items by Name.
        public static int CompareByName(Item a, Item b)
        {
            return string.Compare(a.Name, b.Name, StringComparison.Ordinal);
        }

        // Comparison method for sorting items by Category.
        public static int CompareByCategory(Item a, Item b)
        {
            return string.Compare(a.Category, b.Category, StringComparison.Ordinal);
        }

        // Comparison method for sorting items by Price.
        public static int CompareByPrice(Item a, Item b)
        {
            return a.Price.CompareTo(b.Price);
        }

        //  Bubble Sort 
        public static void BubbleSort(Item[] items, Comparison<Item> compare)
        {
            int n = items.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (compare(items[j], items[j + 1]) > 0)
                    {
                        // Swap the items.
                        Item temp = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = temp;
                    }
                }
            }
        }

        //  Quick Sort 
        public static void QuickSort(Item[] items, int low, int high, Comparison<Item> compare)
        {
            if (low < high)
            {
                int pivotIndex = Partition(items, low, high, compare);
                QuickSort(items, low, pivotIndex - 1, compare);
                QuickSort(items, pivotIndex + 1, high, compare);
            }
        }

        private static int Partition(Item[] items, int low, int high, Comparison<Item> compare)
        {
            Item pivot = items[high]; // Use last element as pivot.
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (compare(items[j], pivot) <= 0)
                {
                    i++;
                    Item temp = items[i];
                    items[i] = items[j];
                    items[j] = temp;
                }
            }
            // Place pivot at the correct position.
            Item tempPivot = items[i + 1];
            items[i + 1] = items[high];
            items[high] = tempPivot;
            return i + 1;
        }

        //Merge Sort 
        public static void MergeSort(Item[] items, Comparison<Item> compare)
        {
            if (items.Length <= 1)
                return;

            int mid = items.Length / 2;
            Item[] left = new Item[mid];
            Item[] right = new Item[items.Length - mid];
            Array.Copy(items, 0, left, 0, mid);
            Array.Copy(items, mid, right, 0, items.Length - mid);

            MergeSort(left, compare);
            MergeSort(right, compare);
            Merge(items, left, right, compare);
        }

        private static void Merge(Item[] items, Item[] left, Item[] right, Comparison<Item> compare)
        {
            int i = 0, j = 0, k = 0;
            while (i < left.Length && j < right.Length)
            {
                if (compare(left[i], right[j]) <= 0)
                {
                    items[k++] = left[i++];
                }
                else
                {
                    items[k++] = right[j++];
                }
            }
            while (i < left.Length)
            {
                items[k++] = left[i++];
            }
            while (j < right.Length)
            {
                items[k++] = right[j++];
            }
        }
    }
}
