using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ProjectOne.Controllers
{
    [Produces("application/json")]
    [Route("api/Azure")]
    public class AzureController : Controller
    {
        private readonly string logicAppUrl = "https://prod-38.westeurope.logic.azure.com:443/workflows/062b1196071c4370b0ec705102673c58/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=UbKo0RrIWEHeKNwU7LqASgCJYGQXfQkzWy4UHEL-qD0";

        [HttpPost("[action]")]
        public async Task<bool> TriggerLogicApp([FromBody]AzureModel model)
        {
            using (var client = new HttpClient())
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(logicAppUrl, content);
                response.EnsureSuccessStatusCode();
                return true;
            }
        }
    }

    public class AzureModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}