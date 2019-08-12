using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataProviderAPI.Handlers
{
	public interface IHandler
	{
		string Handle();
	}
	public class ConnectHandler : IHandler
	{
		public string Handle()
		{
			return Guid.NewGuid().ToString().ToUpper();
		}
	}

	
}
