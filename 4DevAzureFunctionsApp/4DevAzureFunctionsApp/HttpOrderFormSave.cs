
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using System;
using Newtonsoft.Json;

namespace DevAzureFunctionsApp
{
    public static class HttpOrderFormSave
	{
		[FunctionName("Function1")]
		public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]HttpRequest req, TraceWriter log)
		{
			PhotoOrder photoOrder = null;

			try
			{
				var requestBody = new StreamReader(req.Body).ReadToEnd();
				photoOrder = JsonConvert.DeserializeObject<PhotoOrder>(requestBody);
			}
			catch(Exception)
			{
				return new BadRequestObjectResult("Data Invalid");
			}
			return new OkObjectResult("Order processed");
		}
	}
}
