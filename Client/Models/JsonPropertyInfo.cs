using System.Collections.Generic;

namespace JsonlCompare.Client.Models
{
    public class JsonPropertyInfo
    {
        public bool HasChildren => Children.Count > 0;
        public bool Show { get; set; } = true;
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public HashSet<JsonPropertyInfo> Children { get; set; } = new();
        
        protected bool Equals(JsonPropertyInfo other)
        {
            return Path == other.Path;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(JsonPropertyInfo)) return false;
            return Equals((JsonPropertyInfo)obj);
        }

        public override int GetHashCode()
        {
            return Path.GetHashCode();
        }

        public static bool operator ==(JsonPropertyInfo? left, JsonPropertyInfo? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(JsonPropertyInfo? left, JsonPropertyInfo? right)
        {
            return !Equals(left, right);
        }
    }
}