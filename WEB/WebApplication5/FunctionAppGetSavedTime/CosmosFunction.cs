using System;
using CosmosClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace FunctionAppGetSavedTime
{
    public static class CosmosFunction
    {
        static readonly ProgramTest _programTest;

        static CosmosFunction()
        {
            _programTest = new ProgramTest();
            _programTest.InitClient();
        }

        [FunctionName("FunctionGetSavedTime")]
        public static async Task<IActionResult> RunFunctionGetSavedTime(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            DateTime dt = await _programTest.GetSavedTimeItemAsync();

            return new OkObjectResult(dt);
        }

        [FunctionName("Function1")]
        public static async Task<IActionResult> RunFunction1(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}