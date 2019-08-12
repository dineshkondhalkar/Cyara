using System;
using System.Collections.Generic;
using System.Text;

namespace CommonFunctions
{
	public  class DataStore
	{
		public DataStore()
		{
			responses = min = max = avg = total = 0;
		}

		public int responses;	//number of connections
		public int min;	//minimum digits
		public int max;	//maximum digits
		public int avg;    //average number of digits
		public int total;  //total digits so far

	}

	public class DSOperations
	{
		public void AddResponse(int count)
		{
			//update total
			lock (_lock)
			{
				//update min/max
				if (ds.min > count || (ds.min == 0 && count > 0))
					ds.min = count;
				if (ds.max < count)
					ds.max = count;

				//update responses/average/total
				ds.responses++;
				ds.total += count;
				ds.avg = ds.total / ds.responses;
			}
		}

		//will be used only in the tests to assert
		public DataStore GetDataStore()
		{
			lock (_lock)
			{
				return CopyDS();
			}
		}

		//will be used only in the tests to assert
		private DataStore CopyDS()
		{
			DataStore dsCopy = new DataStore();
			dsCopy.avg = ds.avg;
			dsCopy.max = ds.max;
			dsCopy.min = ds.min;
			dsCopy.responses = ds.responses;
			dsCopy.total = ds.total;
			return dsCopy;
		}

		private static object _lock = new object();
		private static DataStore ds = new DataStore();
	}

}
