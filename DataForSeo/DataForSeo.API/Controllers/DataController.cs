namespace DataForSeo.API.Controllers
{
    using DataForSeo.BLL.Interfaces;
    using DataForSeo.Common.DTO;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDataService dataService;

        public DataController(IDataService _dataService)
        {   
            dataService = _dataService;
        }

        [HttpPost]
        public async Task Post([FromBody]DataDTO dataDTO)
        {
            await dataService.PostData(dataDTO);
        }

        [HttpPut]
        public async Task Put([FromBody]DataDTO dataDTO)
        {
            await dataService.EditData(dataDTO);
        }

        [HttpGet]
        public async Task<List<DataDTO>> Get()
        {
            return await dataService.GetData();
        }
    }
}
