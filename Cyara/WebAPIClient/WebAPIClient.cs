using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace APIClient
{
	public class WebAPIClient
	{
		public string ConnectToDataProvider(string url)
		{
			HttpResponseMessage response =  MakeGetCallToURL(url);
			response.EnsureSuccessStatusCode();
			Task<string> result = response.Content.ReadAsStringAsync();
			return result.Result;
		}

		public void ConnectToAggregator(string url, int count)
		{
			HttpResponseMessage response = MakePutCallToURL(string.Format("{0}/{1}", url, count), count);
			response.EnsureSuccessStatusCode();
			Task<string> result = response.Content.ReadAsStringAsync();
			return;
		}

		private HttpResponseMessage MakeGetCallToURL(string url)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(url);

			// Add an Accept header for JSON format.
			client.DefaultRequestHeaders.Accept.Add(
			new MediaTypeWithQualityHeaderValue("application/json"));

			// List data response.
			HttpResponseMessage response = client.GetAsync(string.Empty).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
			return response;
		}

		private HttpResponseMessage MakePutCallToURL(string url, int count)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(url);

			// Add an Accept header for JSON format.
			client.DefaultRequestHeaders.Accept.Add(
			new MediaTypeWithQualityHeaderValue("application/json"));

			StringContent stringContent = new StringContent(string.Format("{0}", count));
			// List data response.
			Task<HttpResponseMessage> response = client.PutAsync(url, stringContent);  // Blocking call! Program will wait here until a response is received or a timeout occurs.
			response.Wait();
			return response.Result;
		}
	}
}
