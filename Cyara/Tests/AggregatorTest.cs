using System;
using Xunit;
using CommonFunctions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests
{
	public class AggregatorTest
	{
		[Fact]
		public void TestAggregator()
		{
			DSOperations dsOperations = new DSOperations();
			dsOperations.AddResponse(15);
			DataStore ds = dsOperations.GetDataStore();
			Assert.Equal(15, ds.avg);
			Assert.Equal(15, ds.total);
			Assert.Equal(15, ds.max);
			Assert.Equal(1, ds.responses);

			dsOperations.AddResponse(10);
			ds = dsOperations.GetDataStore();
			Assert.Equal(12, ds.avg);
			Assert.Equal(25, ds.total);
			Assert.Equal(15, ds.max);
			Assert.Equal(10, ds.min);
			Assert.Equal(2, ds.responses);
		}

		[Fact]
		public void TestAggregatorConcurrent()
		{
			DSOperations dsOperations = new DSOperations();
			List<Task> TaskList = new List<Task>();
			//create 5 concurrent execution paths (threads)
			//starting from 5 to have a greater number added
			for (int i = 5; i <= 10; i++)
			{
				int j = i;	//for enclosure
				Task task = new Task(() => dsOperations.AddResponse(j));
				task.Start();
				TaskList.Add(task);
			}

			Task.WaitAll(TaskList.ToArray());

			DataStore ds = dsOperations.GetDataStore();
			Assert.Equal(7, ds.avg);
			Assert.Equal(45, ds.total);
			Assert.Equal(10, ds.max);
			Assert.Equal(5, ds.min);
			Assert.Equal(6, ds.responses);
		}
	}
}
