using System.Collections.Generic;
using Domain.Algorithms.QuickSort;
using Domain.Algorithms.QuickSort.Service;

namespace Application.AlgorithmsApplication
{
    public class AlgorithmsAppService : IAlgorithmsAppService
    {
        private readonly IQuickSortService quickSortService;

        public AlgorithmsAppService(IQuickSortService quickSortService)
        {
            this.quickSortService = quickSortService;
        }

        public List<List<QuickSortData>> QuickSort(int[] datas)
        {
            return quickSortService.QuickSort(datas);
        }
    }
}
