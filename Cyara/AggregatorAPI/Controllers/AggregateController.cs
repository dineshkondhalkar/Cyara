using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommonFunctions;

namespace AggregatorAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AggregateController : ControllerBase
	{
		// PUT api/aggregate/5
		[HttpPut("{count}")]
		public void Put(int count)
		{
			DSOperations datastore = new DSOperations();
			datastore.AddResponse(count);
		}

		[HttpGet]
		public string Get()
		{
			return "Test Agregate";
		}
	}
}
