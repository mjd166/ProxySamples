namespace FetchingDataFromDataService
{
    /// <summary>
    /// Proxy
    /// </summary>
    public class DataServiceProxy : IDataService
    {
        private RealDataService _realDataService;
        private bool _hasAccess;

        public DataServiceProxy(bool hasAccess)
        {
            _hasAccess = hasAccess;
        }

        public void GetData()
        {
            if (!_hasAccess)
            {
                Console.WriteLine("Access denied: You don't have permission to access this data.");
                return;
            }
          
            if(_realDataService == null)
            {
                _realDataService = new RealDataService();
            }

            Console.WriteLine("Proxy: Checking permissions and initializing real service if needed...");
            _realDataService.GetData();

        }
    }
}
