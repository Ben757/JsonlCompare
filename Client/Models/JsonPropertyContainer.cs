using System.Collections.Generic;

namespace JsonlCompare.Client.Models
{
    public class JsonPropertyContainer
    {
        public bool HasChildren => Children.Count > 0;
        public string Name { get; set; }
        public IReadOnlyList<JsonPropertyContainer> Children { get; set; } = new List<JsonPropertyContainer>();
    }
}