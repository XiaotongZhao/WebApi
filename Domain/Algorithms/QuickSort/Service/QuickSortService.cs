using System.Linq;
using System.Collections.Generic;

namespace Domain.Algorithms.QuickSort.Service
{
    public class QuickSortService : IQuickSortService
    {
        private List<List<QuickSortData>> result = new List<List<QuickSortData>>();

        private void addSourtedResult(int[] datas, int firstIndex, int secondIndex)
        {
            var quickSortDatas = new List<QuickSortData>();
            for (int index = 0; index < datas.Length; index++)
            {
                quickSortDatas.Add(new QuickSortData { Value = datas[index], Change = index == firstIndex || index == secondIndex });
            }
            result.Add(quickSortDatas);
        }

        private void exChange(int[] datas, int firstIndex, int secondIndex)
        {
            if (firstIndex != secondIndex)
            {
                datas[firstIndex] ^= datas[secondIndex];
                datas[secondIndex] = datas[firstIndex] ^ datas[secondIndex];
                datas[firstIndex] ^= datas[secondIndex];
                addSourtedResult(datas, firstIndex, secondIndex);
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
                Sort(datas, start, middleIndex - 1);
                Sort(datas, middleIndex + 1, end);
            }
        }

        public List<List<QuickSortData>> QuickSort(int[] datas)
        {
            Sort(datas, 0, datas.Length - 1);
            return result;
        }
    }
}
