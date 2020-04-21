using Domain.Algorithms.QuickSort;
using System.Collections.Generic;

namespace Application.AlgorithmsApplication
{
    public interface IAlgorithmsAppService
    {
        List<List<QuickSortData>> QuickSort(int[] datas);
    }
}
