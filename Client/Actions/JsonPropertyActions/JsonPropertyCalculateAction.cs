using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace JsonlCompare.Client.Actions.JsonPropertyActions
{
    public class JsonPropertyCalculateAction
    {
        public IReadOnlyList<JObject> Jsons { get; }

        public JsonPropertyCalculateAction(IReadOnlyList<JObject> jsons)
        {
            Jsons = jsons;
        }
    }
}