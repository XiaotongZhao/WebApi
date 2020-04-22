using System.Collections.Generic;

namespace Domain.Algorithms.QuickSort.Service
{
    public interface IQuickSortService
    {
        List<List<QuickSortData>> QuickSort(int[] datas);
    }
}
