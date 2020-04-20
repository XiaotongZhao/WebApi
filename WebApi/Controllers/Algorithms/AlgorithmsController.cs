using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Controllers.Base;
using Application.AlgorithmsApplication;
using System.Collections.Generic;

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
        public List<List<int>> QuickSort(int[] datas)
        {
            return algorithmsAppService.QuickSort(datas);
        }
    }
}
