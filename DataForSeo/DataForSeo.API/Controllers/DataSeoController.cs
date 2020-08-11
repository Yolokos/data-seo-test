namespace DataForSeo.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using DataForSeo.API.Requests;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    [Route("api/[controller]")]
    [ApiController]
    public class DataSeoController : ControllerBase
    {
        private readonly HttpClient httpClient;

        public DataSeoController()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.dataforseo.com/"),
                DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes("challenger28@rankactive.info:W8DQXc6V5"))) }
            };
        }

        [HttpGet("regions/{searchEngine}")]
        public async Task<ActionResult> GetRegions(string searchEngine)
        {
            var response = await httpClient.GetAsync($"/v3/serp/{searchEngine}/locations/NZ");
            var result = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());

            return new JsonResult(result);
        }


        [HttpGet("check_status/{searchEngine}/{taskId}")]
        public async Task<ActionResult> Check(string searchEngine, string taskId)
        {
            var response = await httpClient.GetAsync($"/v3/serp/{searchEngine}/organic/task_get/regular/{taskId}");
            var tasksInfo = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());

            return new JsonResult(tasksInfo);
        }

        [HttpPost("send")]
        public async Task<ActionResult> Send([FromBody]DataRequestModel request)
        {
            var postDataTasks = new List<object>();

            foreach (var word in request.KeyWords)
            {
                postDataTasks.Add(new
                {
                    language_code = "en",
                    location_code = request.LocationCode,
                    priority = 2,
                    keyword = word
                });
            }

            var taskPostResponse = await httpClient.PostAsync($"/v3/serp/{request.SearchEngine}/organic/task_post", new StringContent(JsonConvert.SerializeObject(postDataTasks)));
            var result = JsonConvert.DeserializeObject<dynamic>(await taskPostResponse.Content.ReadAsStringAsync());

            return new JsonResult(result);
        }
    }
}
