using Microsoft.Azure.Cosmos;
using Microsoft.Azure.WebJobs.Description;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using any = System.Collections.Generic.Dictionary<string, object>;

namespace cyber_reporting_processing.Database
{
    internal class DatabaseHandler
    {
        private Container _cosmosContainer;

        public DatabaseHandler()
        {
            var connStr = Environment.GetEnvironmentVariable("CONNECTION_STRING_COSMOS");
            var cosmosClient = new CosmosClient(connStr);
            var db = cosmosClient.GetDatabase("ReportingDb");
            this._cosmosContainer = db.GetContainer("ReportingDb");
        }

        public async Task<ItemResponse<object>> AddItemToDatabase(object item)
        {
            return await this._cosmosContainer.CreateItemAsync(item);
        }
    }
}
