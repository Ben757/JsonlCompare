using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace JsonlCompare.Client.Actions.Json
{
    public class JsonUpdateAction
    {
        public IReadOnlyList<JObject> Jsons { get; }

        public JsonUpdateAction(IReadOnlyList<JObject> jsons)
        {
            Jsons = jsons;
        }
    }
}