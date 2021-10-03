using Fluxor;
using JsonlCompare.Client.Actions.SelectedJson;
using Newtonsoft.Json.Linq;

namespace JsonlCompare.Client.Store.SelectedJson
{
    public record SelectedJsonState
    {
        public JObject? SelectedJson { get; init; }
    }
    
    public class SelectedJsonFeature : Feature<SelectedJsonState>
    {
        public override string GetName() => "SelectedJson";

        protected override SelectedJsonState GetInitialState()
        {
            return new SelectedJsonState()
            {
                SelectedJson = null
            };
        }
    }

    public static class SelectedJsonReducers
    {
        [ReducerMethod]
        public static SelectedJsonState OnSet(SelectedJsonState state, SelectedJsonSetAction action)
        {
            return state with { SelectedJson = action.Json };
        }
    }
}