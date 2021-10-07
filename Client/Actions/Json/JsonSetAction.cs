using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace JsonlCompare.Client.Actions.Json
{
    public class JsonSetAction
    {
        public IReadOnlyList<JObject> Jsons { get; }

        public JsonSetAction(IReadOnlyList<JObject> jsons)
        {
            Jsons = jsons;
        }
    }
}