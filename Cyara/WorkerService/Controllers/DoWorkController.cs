using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WorkerService.Workers;

namespace WorkerService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WorkerController : ControllerBase
	{
		public WorkerController(IConfiguration config, IWorker _worker)
		{
			this.config = config;
			worker = _worker;
		}
		
		// GET api/worker
		[HttpGet]
		public int Get()
		{
			//perform connect requests to the data provider and submit those to the aggregator
			// returns the number of digits from 0-9 for this connection
			return worker.DoWork(config);
		}

		private IWorker worker;
		IConfiguration config;
	}
}
