using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Controllers.Base;
using Application.AlgorithmsApplication;
using System.Collections.Generic;
using System.Threading.Tasks;
using Consul;
using Domain.Algorithms.QuickSort;
using Microsoft.Extensions.Configuration;

namespace WebApi.Controllers.Algorithms
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlgorithmsController : BaseController
    {
        private readonly IAlgorithmsAppService algorithmsAppService;
        private readonly IConfiguration configuration;  
        public AlgorithmsController(IConfiguration configuration, IAlgorithmsAppService algorithmsAppService)
        {
            this.configuration = configuration;  
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
            var test = configuration.GetConnectionString("DBConnection");
            return test;
        }
    }
}
