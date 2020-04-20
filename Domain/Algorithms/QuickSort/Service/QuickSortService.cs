using System.Linq;
using System.Collections.Generic;

namespace Domain.Algorithms.QuickSort.Service
{
    public class QuickSortService : IQuickSortService
    {
        private List<List<int>> result = new List<List<int>>();

        private void addSourtedResult(int[] datas)
        {
            result.Add((datas.Clone() as int[]).ToList());
        }

        private void exChange(int[] datas, int firstIndex, int secondIndex)
        {
            if (firstIndex != secondIndex)
            {
                datas[firstIndex] ^= datas[secondIndex];
                datas[secondIndex] = datas[firstIndex] ^ datas[secondIndex];
                datas[firstIndex] ^= datas[secondIndex];
            }
        }

        private int partition(int[] datas, int start, int end)
        {
            int i = start - 1;
            int middleValue = datas[end];
            for (int j = start; j < end; j++)
            {
                if (datas[j] < middleValue)
                {
                    exChange(datas, ++i, j);
                }
            }
            exChange(datas, ++i, end);
            return i;
        }

        private void Sort(int[] datas, int start, int end)
        {
            if (start <= end)
            {
                int middleIndex = partition(datas, start, end);
                addSourtedResult(datas);
                Sort(datas, start, middleIndex - 1);
                Sort(datas, middleIndex + 1, end);
            }
        }

        public List<List<int>> QuickSort(int[] datas)
        {
            Sort(datas, 0, datas.Length - 1);
            return result;
        }
    }
}
