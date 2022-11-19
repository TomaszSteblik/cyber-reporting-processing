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
            var connStr = "AccountEndpoint=https://cyber-cosmos-db.documents.azure.com:443/;AccountKey=MzPWSxcuqo5NUU6XtJxFsCKkWWeHpgp3DB1D5UoJCWMSSis8amDItxt7KQ5V4opQoAMpVdsEboOuACDb3lGwmQ==;";
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
