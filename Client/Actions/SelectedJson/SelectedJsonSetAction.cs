using Newtonsoft.Json.Linq;

namespace JsonlCompare.Client.Actions.SelectedJson
{
    public class SelectedJsonSetAction
    {
        public JObject Json { get; }

        public SelectedJsonSetAction(JObject json)
        {
            Json = json;
        }
    }
}