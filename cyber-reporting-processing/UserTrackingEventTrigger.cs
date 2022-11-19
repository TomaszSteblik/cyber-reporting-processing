using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using cyber_reporting_processing.Database;
using cyber_reporting_processing.Enums;
using cyber_reporting_processing.Extensions;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using any = System.Collections.Generic.Dictionary<string, object>;

namespace cyber_reporting_processing;

public static class UserTrackingEventTrigger
{
    [FunctionName("userTrackingEventTrigger")]
    public static async Task RunAsync([ServiceBusTrigger("%QUEUE_NAME%", Connection = "CONNECTION_STRING_SERVICE_BUS")] string queueItem, ILogger log)
    {
        var eventTypes = new EventTypes();

        var parsedQueueItem = JsonConvert.DeserializeObject<any>(queueItem);
        var eventName = parsedQueueItem["Event"];
        var eventValue = parsedQueueItem["Value"].toAny();
        
        var db = new DatabaseHandler();

        var eventBody = new
        {
            id = Guid.NewGuid().ToString(),
            user_id = eventValue["UserId"],
            username = eventValue["Username"],
            timestamp = eventValue["UnixTimeStamp"],
            event_type = eventTypes[eventName as string]
        };


        var result = await db.AddItemToDatabase(eventBody);
        
        Console.WriteLine(result.StatusCode);
    }
}