using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerService.Helpers
{
	public class GuidHelper
	{
		public static bool IsValidGuid(string guid)
		{
			Guid objGuid;
			return Guid.TryParse(guid, out objGuid);
		}

		public static int CountDigitsInGuid(string guid)
		{
			int count = 0;
			foreach (char c in guid)
			{
				if (c >= '0' && c <= '9')
				{
					count++;
				}
			}
			return count;
		}
	}
}
