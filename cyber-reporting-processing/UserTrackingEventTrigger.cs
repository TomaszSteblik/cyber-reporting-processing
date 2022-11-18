using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace cyber_reporting_processing;

public static class UserTrackingEventTrigger
{
    [FunctionName("userTrackingEventTrigger")]
    public static async Task RunAsync([ServiceBusTrigger("%QUEUE_NAME%", Connection = "CONNECTION_STRING_SERVICE_BUS")] string myQueueItem, ILogger log)
    {
        log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        
    }
}