using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infrastructure.Mongo.Context
{
    public class TasteefContext
    {
        private const string _databaseName = "Dynamicdata";
        private static readonly object syncLock = new object();
        private static TasteefContext _instance;

        protected TasteefContext()
        {
            IConfigurationBuilder _config = new ConfigurationBuilder();

            var connectionString = Configuration.GetSection("ConnectionString").Value; // "mongodb://localhost:27017";
            Client = new MongoClient(connectionString);
            Database = Client.GetDatabase(_databaseName);
        }

        /// <summary>
        ///     The default key Tasteef.Repository will look for in the App.config or Web.config file.
        /// </summary>
        private IConfiguration Configuration { get; set; }

        private IMongoClient Client { get; }

        public IMongoDatabase Database { get; set; }

        // private static MongoContext _MongoContext=new MongoContext();
        public static TasteefContext GetTasteefContext()
        {
            if (_instance == null)
                lock (syncLock)
                {
                    if (_instance == null) _instance = new TasteefContext();
                }

            return _instance;
        }

       
    }
}
