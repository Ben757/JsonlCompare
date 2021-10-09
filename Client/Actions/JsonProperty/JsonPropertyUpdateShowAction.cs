using JsonlCompare.Client.Models;

namespace JsonlCompare.Client.Actions.JsonProperty
{
    public class JsonPropertyUpdateShowAction
    {
        public JsonPropertyInfo PropertyInfo { get; }

        public JsonPropertyUpdateShowAction(JsonPropertyInfo propertyInfo)
        {
            PropertyInfo = propertyInfo;
        }
    }
}