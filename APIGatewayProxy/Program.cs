using APIGatewayProxy;

IApiService apiService = new ApiServiceProxy();

string url = "https://jsonplaceholder.typicode.com/posts/1";

Console.WriteLine("First request:");
Console.WriteLine(await apiService.GetDataAsync(url));

Console.WriteLine("\nSecond request (cached):");
Console.WriteLine(await apiService.GetDataAsync(url));

Thread.Sleep(5000);
Console.WriteLine("\nThird request (rate limit test):");
Console.WriteLine(await apiService.GetDataAsync(url));