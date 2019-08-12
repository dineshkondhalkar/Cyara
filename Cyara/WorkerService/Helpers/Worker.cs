using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkerService.Helpers;
using APIClient;

namespace WorkerService.Workers
{
	public interface IWorker
	{
		int DoWork(IConfiguration config);
	}

	public class Worker : IWorker
	{
		public object WebAPIClient { get; private set; }

		/// <summary>
		/// will perform connect to the Data provider and then return the number of digits from 0-9 
		/// </summary>
		public int DoWork(IConfiguration config)
		{
			int countOfDigits = 0;
			try
			{
				///First go to the Data provider and get the guid
				string DataProviderURL = (string)config.GetValue(typeof(string), "DataProvider");
				string guid = ConnectToDataProvider(DataProviderURL);
				countOfDigits = CountDigits(guid);

				//now pass the count of the digits to the aggregator
				string AggregatorURL = (string)config.GetValue(typeof(string), "Aggregator");
				ConnectToAggregator(AggregatorURL, countOfDigits);
				
			}
			catch(Exception ex)
			{

			}
			return countOfDigits;
		}

		private int CountDigits(string guid)
		{
			if(!GuidHelper.IsValidGuid(guid))
			{
				throw new Exception("Invalid guid specified");
			}

			return GuidHelper.CountDigitsInGuid(guid);

		}

		private string ConnectToDataProvider(string DataProviderURL)
		{
			WebAPIClient client = new WebAPIClient();
			string guid = client.ConnectToDataProvider(DataProviderURL);
			
			return guid;
		}

		private void ConnectToAggregator(string DataProviderURL, int count)
		{
			WebAPIClient client = new WebAPIClient();
			client.ConnectToAggregator(DataProviderURL, count);
		}
	}

}
