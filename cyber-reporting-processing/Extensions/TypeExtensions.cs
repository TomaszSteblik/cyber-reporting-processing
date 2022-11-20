using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using any = System.Collections.Generic.Dictionary<string, object>;

namespace cyber_reporting_processing.Extensions
{
    internal static class TypeExtensions
    {
        public static any toAny(this object obj)
        {
            return JsonConvert.DeserializeObject<any>(JsonConvert.SerializeObject(obj));
        }
    }
}
