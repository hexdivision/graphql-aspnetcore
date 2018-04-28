using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PathWays.Common.Utilities
{
    public static class PatchHelper
    {
        public static T ApplyPatchTo<T>(this object request, ref T entity)
        {
            var requestJson = JsonConvert.SerializeObject(request, Formatting.None).ToLower();
            var requestJobj = JObject.Parse(requestJson);

            var entityJson = JsonConvert.SerializeObject(entity, Formatting.None).ToLower();
            var entityJobj = JObject.Parse(entityJson);

            entityJobj.Merge(requestJobj, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Union, MergeNullValueHandling = MergeNullValueHandling.Merge });

            entity = JsonConvert.DeserializeObject<T>(entityJobj.ToString());

            return entity;
        }
    }
}
