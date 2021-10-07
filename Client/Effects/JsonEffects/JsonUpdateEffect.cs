using System.Threading.Tasks;
using Fluxor;
using JsonlCompare.Client.Actions.Json;
using JsonlCompare.Client.Actions.JsonProperty;

namespace JsonlCompare.Client.Effects.JsonEffects
{
    public class JsonUpdateEffect
    {
        [EffectMethod]
        public Task UpdateJsons(JsonUpdateAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new JsonSetAction(action.Jsons));
            dispatcher.Dispatch(new JsonPropertyCalculateAction(action.Jsons));

            return Task.CompletedTask;
        }
    }
}