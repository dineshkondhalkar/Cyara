using System;
using Xunit;
using WorkerService.Helpers;


namespace Tests
{
	public class WorkerTests
	{
		[Theory]
		[InlineData("8CE210B8-31B8-4D7B-8DA6-E62C47C7CB75", 19)]
		[InlineData("8CE210B8-31B8-4D7B-8DA6-ED2C47C7CB75", 18)]
		[InlineData("8CE210B8-31B8-4D7B-BDA6-ED2C4CC7CB75", 16)]
		public void CheckDigitCount(string guid, int countExpected)
		{
			int count = GuidHelper.CountDigitsInGuid(guid);
			Assert.Equal(countExpected, count);
		}

		[Theory]
		[InlineData("8CE210B8-31B8-4D7B-8DA6-E62C47C7CB75", true)]
		[InlineData("8CE210B8-31B8-4D7B-8DA6-E62C47C7ZB75", false)]
		[InlineData("", false)]
		public void CheckIfValidGuid(string guid, bool valid)
		{
			bool isValid = GuidHelper.IsValidGuid(guid);
			Assert.Equal(valid, isValid);
		}

	}
}
