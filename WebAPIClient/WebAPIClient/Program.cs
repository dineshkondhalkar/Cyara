using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebAPIClient
{
	class Program
	{
		private static HttpResponseMessage MakePutCallToURL(string url, int count)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(url);

			// Add an Accept header for JSON format.
			client.DefaultRequestHeaders.Accept.Add(
			new MediaTypeWithQualityHeaderValue("application/json"));

			StringContent stringContent = new StringContent(string.Format("{0}", count),
				System.Text.Encoding.UTF8,
				"application/json");
			// List data response.
			client.PutAsync(url, stringContent).Wait();  // Blocking call! Program will wait here until a response is received or a timeout occurs.
			return new HttpResponseMessage();
		}

		private static HttpResponseMessage MakeGetCallToURL(string url)
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
		static void Main(string[] args)
		{
			//I could have made this configurable by accepting the number of threads as an argument
			Task[] tasks = new Task[5];
			tasks[0] = new Task(() => Program.MakeGetCallToURL("http://localhost:51686/api/worker"));
			tasks[1] = new Task(() => Program.MakeGetCallToURL("http://localhost:51686/api/worker"));
			tasks[2] = new Task(() => Program.MakeGetCallToURL("http://localhost:51686/api/worker"));
			tasks[3] = new Task(() => Program.MakeGetCallToURL("http://localhost:51686/api/worker"));
			tasks[4] = new Task(() => Program.MakeGetCallToURL("http://localhost:51686/api/worker"));

			foreach(Task t in tasks)
			{
				t.Start();
			}

			Task.WaitAll(tasks);

			//Program.MakePutCallToURL("http://localhost:51986/api/aggregate/4", 4);
		}
	}
}
