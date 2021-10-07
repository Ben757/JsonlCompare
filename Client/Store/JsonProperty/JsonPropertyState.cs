using System.Collections.Generic;
using System.Linq;
using Fluxor;
using JsonlCompare.Client.Actions.JsonProperty;
using JsonlCompare.Client.Extensions;
using JsonlCompare.Client.Models;
using JsonlCompare.Client.Services;

namespace JsonlCompare.Client.Store.JsonProperty
{
    public record JsonPropertyState
    {
        public IReadOnlyList<JsonPropertyInfo> PropertyInfos { get; init; } = new List<JsonPropertyInfo>();
    }
    
    public class JsonPropertyFeature : Feature<JsonPropertyState>
    {
        public override string GetName() => "JsonProperty";

        protected override JsonPropertyState GetInitialState()
        {
            return new JsonPropertyState()
            {
                PropertyInfos = new List<JsonPropertyInfo>()
            };
        }
    }

    public static class JsonPropertyReducers
    {
        [ReducerMethod]
        public static JsonPropertyState OnCalculate(JsonPropertyState state, JsonPropertyCalculateAction action)
        {
            return state with { PropertyInfos = PropertyInfoService.PropertyInfos(action.Jsons) };
        }

        [ReducerMethod]
        public static JsonPropertyState OnUpdateShow(JsonPropertyState state, JsonPropertyUpdateShowAction action)
        {
            var jsonPropertyInfo = state.PropertyInfos
                .SelectMany(x => x.EnumerateChildren())
                .Single(x => x.Path.Equals(action.PropertyInfo.Path));

            jsonPropertyInfo.Show = action.PropertyInfo.Show;
            
            return state with { PropertyInfos = state.PropertyInfos } ;
        }
    }
}