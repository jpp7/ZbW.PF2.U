using System;
using System.Collections.Generic;
using System.Linq;

namespace MB15.SortComparison.SortingAlgorithms
{
    /// <summary>
    /// Represents the Bucket Sort algorithm, an efficient sorting algorithm utilizing
    /// the divide-and-conquer principle by distributing elements into buckets based
    /// on their values and subsequently sorting each bucket individually.
    /// </summary>
    /// <remarks>
    /// Bucket Sort is suitable for sorting datasets where the input is uniformly distributed
    /// over a range and the size of the dataset is reasonably large.
    /// It works by dividing the input into several buckets, sorting the contents of each bucket,
    /// and then concatenating the buckets to produce the sorted output.
    /// </remarks>
    public sealed class Bucketsort : SortAlgorithm
    {
        public override string Name => "Bucketsort";

        /// <summary>
        /// Sorts a given list of integers using the Bucket Sort algorithm.
        /// </summary>
        /// <param name="arrayToSort">
        /// The list of integers to be sorted in-place. The input must be a non-null list and can have zero or more elements.
        /// </param>
        /// <remarks>
        /// This method uses the Bucket Sort algorithm, which organizes input data into several buckets,
        /// sorts each bucket individually, and combines the buckets to produce the sorted output.
        /// </remarks>
        public override void Sort(IList<int> arrayToSort)
        {
            // Prüfen ob Array leer ist
            if (arrayToSort.Count == 0)
            {
                return;
            }

            // Minimum und Maximum finden
            int min = arrayToSort.Min();
            int max = arrayToSort.Max();

            // Anzahl der Buckets berechnen (Wurzel der Array-Länge)
            var bucketCount = (int)Math.Sqrt(arrayToSort.Count);

            // Grösse der einzelnen Buckets berechnen
            var bucketSize = (max - min) / bucketCount + 1;

            // Array von Buckets erstellen und initialisieren
            var buckets = new List<int>[bucketCount];
            for (var i = 0; i < bucketCount; i++)
            {
                buckets[i] = new List<int>();
            }

            // Werte in Buckets verteilen
            foreach (var value in arrayToSort)
            {
                int bucketIndex = (value - min) / bucketSize;
                buckets[bucketIndex].Add(value);
            }

            // Buckets sortieren und zurück ins Array schreiben
            int arrayIndex = 0;
            foreach (var bucket in buckets)
            {
                bucket.Sort(); // Jeden Bucket einzeln sortieren
                foreach (var value in bucket)
                {
                    arrayToSort[arrayIndex] = value;
                    arrayIndex++;
                }
            }
        }
    }
}