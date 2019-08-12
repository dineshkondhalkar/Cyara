# Cyara
Cyara coding test
Cyara Coding test:
Environment:
  Visual Studio 2019 (community edition) with .NET core 2.2

Code:
  There are three web API projects created in the solution CyaraTest
	- Aggregator	: This service updates the statistics such as average, total, response count, max and min
	- DataProvider	: This service will accept the connection from the worker service and return a GUID on success.
	- WorkerService	: Th‪is service is the origin of all calls. It will accept the request from the client (such as a browser) and then make a connection to the aggregator service with the count of digits from 0-9 in th Guids. 
	- Test		: Has unit tests for the aggregator and the worker service
	- CommonFunctions: has some code that is common and independent of the services.


I have also created a webapiclient project which is in its own solution. It spawns five threads which send the request to the WorkerService in parallel. This can be used to test the entire project end to end.
I have run the following commands in separate dev env command windows to fire up the web apis:
dotnet run --project <project path>

WebAPIClient (5 parallel calls) ---------> WorkerService -------------------> DataProvider Service (returns Guid to WorkerService)
						|
						----------------------------> Count digits (0-9) in Guid
						|
						----------------------------> Aggregator Service (maintains digit statistics)
