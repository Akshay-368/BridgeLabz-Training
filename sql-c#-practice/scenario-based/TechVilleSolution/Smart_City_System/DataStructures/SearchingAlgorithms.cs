// File: DataStructures/SearchingAlgorithms.cs

namespace SmartCitySmartCity.DataStructures
{
    public static class SearchingAlgorithms
    {
        // Linear Search – works on unsorted data
        public static int LinearSearch(int[] array, int target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                    return i;
            }

            return -1;
        }

        // Binary Search – requires sorted data
        public static int BinarySearch(int[] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (array[mid] == target)
                    return mid;

                if (array[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }
    }
}
