using System.Collections.Generic;
using Fluxor;
using JsonlCompare.Client.Actions.JsonActions;
using Newtonsoft.Json.Linq;

namespace JsonlCompare.Client.Store.Json
{
    public record JsonState
    {
        public IReadOnlyList<JObject> Jsons { get; init; } = new List<JObject>();
    }
    
    public class JsonFeature : Feature<JsonState>
    {
        public override string GetName() => "Json";

        protected override JsonState GetInitialState()
        {
            return new JsonState()
            {
                Jsons = new List<JObject>()
            };
        }
    }

    public static class JsonReducers
    {
        [ReducerMethod]
        public static JsonState OnSet(JsonState state, JsonSetAction action)
        {
            return state with { Jsons = action.Jsons };
        }
    }
}