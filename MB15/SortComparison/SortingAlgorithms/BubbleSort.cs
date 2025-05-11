using System.Collections.Generic;

namespace MB15.SortComparison.SortingAlgorithms
{
    public class BubbleSort : SortAlgorithm
    {
        public override string Name => "Bubblesort";

        public override void Sort(IList<int> arrayToSort)
        {
            // int n = arrayToSort.Count;
            // while (n > 1)
            // {
            //     int lastSwapIndex = 0;
            //     for (int j = 1; j < n; j++)
            //     {
            //         if (arrayToSort[j - 1] > arrayToSort[j])
            //         {
            //             SwapItems(arrayToSort, j - 1, j);
            //             lastSwapIndex = j;
            //         }
            //     }
            //
            //     n = lastSwapIndex; // Ab hier ist alles sortiert
            // }
        }

        private void SwapItems(IList<int> arrayToSort, int index1, int index2)
        {
            // var temp = arrayToSort[index1];
            // arrayToSort[index1] = arrayToSort[index2];
            // arrayToSort[index2] = temp;
        }
    }
}