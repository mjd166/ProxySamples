using FetchingDataFromDataService;

Console.WriteLine("Client with access:");
IDataService serviceWithAccess = new DataServiceProxy(true);
serviceWithAccess.GetData();

Console.WriteLine();

Console.WriteLine("Client without access:");
IDataService serviceWithoutAccess = new DataServiceProxy(false);
serviceWithoutAccess.GetData();