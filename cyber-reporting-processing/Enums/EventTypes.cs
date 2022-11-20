using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace cyber_reporting_processing.Enums
{
    public class EventTypes
    {
        public string UserLoggedIn => "user_logged_in";
        public string UserLoggedOut => "user_logged_out";
        public string UserCreated => "user_created";
        public string UserDeleted => "user_deleted";
        public string UserPasswordChanged => "user_password_changed";
        public string UserPasswordReset => "user_password_reset";

        public object this[string name]
        {
            get
            {
                var properties = typeof(EventTypes)
                        .GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var property in properties)
                {
                    if (property.Name == name && property.CanRead)
                        return property.GetValue(this, null);
                }

                throw new ArgumentException("Can't find property " + name);

            }
            set
            {
                return;
            }
        }
    }
}
