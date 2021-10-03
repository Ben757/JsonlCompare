using System.Collections.Generic;
using JsonlCompare.Client.Models;

namespace JsonlCompare.Client.Actions.JsonPropertyActions
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