using System.Collections.Generic;

namespace JsonlCompare.Client.Models
{
    public class JsonPropertyInfo
    {
        public bool HasChildren => Children.Count > 0;
        public bool Show { get; set; } = true;
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public IReadOnlyList<JsonPropertyInfo> Children { get; set; } = new List<JsonPropertyInfo>();
    }
}