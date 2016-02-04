using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace MvcApplication.Utils
{
    public static class ObjectCopier
    {
        public static T Clone<T>(T source)
        {
            if (source == null)
            {
                return default(T);
            }

            var json = JsonConvert.SerializeObject(source);

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
