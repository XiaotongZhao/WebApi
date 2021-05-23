using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Controllers.Base;
using Application.AlgorithmsApplication;
using System.Collections.Generic;
using Domain.Algorithms.QuickSort;

namespace WebApi.Controllers.Algorithms
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlgorithmsController : BaseController
    {
        private readonly IAlgorithmsAppService algorithmsAppService;

        public AlgorithmsController(IAlgorithmsAppService algorithmsAppService)
        {
            this.algorithmsAppService = algorithmsAppService;
        }

        [HttpPost]
        [Route("QuickSort")]
        public List<List<QuickSortData>> QuickSort(int[] datas)
        {
            return algorithmsAppService.QuickSort(datas);
        }
        
        [HttpGet]
        [Route("Test")]
        public string Test()
        {
            return "this is a test";
        }
    }
}
