using System.Collections.Generic;

namespace JsonlCompare.Client.Models
{
    public class JsonPropertyInfo
    {
        public bool HasChildren => Children.Count > 0;
        public bool Show { get; set; } = true;
        public string Name { get; set; }
        public string Path { get; set; }
        public IReadOnlyList<JsonPropertyInfo> Children { get; set; } = new List<JsonPropertyInfo>();
    }
}