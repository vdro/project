using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using ProjectOne.Models;
using ProjectOne.Interfaces;

namespace ProjectOne.Controllers
{
    [Produces("application/json")]
    [Route("api/Azure")]
    public class AzureController : Controller
    {
        private readonly IAzureService azureService;

        public AzureController(IAzureService azureService)
        {
            this.azureService = azureService;
        }

        [HttpPost("[action]")]
        public async Task<bool> TriggerLogicApp([FromBody]AzureModel model)
        {
            return await azureService.TriggerLogicApp(model);
        }
    }
}