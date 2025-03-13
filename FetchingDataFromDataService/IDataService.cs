namespace FetchingDataFromDataService
{
    /// <summary>
    /// Subject Interface
    /// </summary>
    public interface IDataService
    {
        void GetData();
    }



    /// <summary>
    /// Real Subject
    /// </summary>
    public class RealDataService : IDataService
    {
        public void GetData()
        {
            Console.WriteLine("Fetching data from the real data service...");
        }
    }
}
