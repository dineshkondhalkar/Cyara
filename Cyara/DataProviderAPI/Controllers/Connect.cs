using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataProviderAPI.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace DataProviderAPI.Controllers
{
    [Route("api/[controller]")]
    public class ConnectController : Controller
    {
		public ConnectController(IHandler _handler)
		{
			handler = _handler;
		}

        // GET api/values
        [HttpGet, Produces("text/plain")]
        public string Connect()
        {
            return handler.Handle();
        }

		private IHandler handler;
    }
}
