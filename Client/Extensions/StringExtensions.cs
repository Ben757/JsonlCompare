using Microsoft.AspNetCore.Components;

namespace JsonlCompare.Client.Extensions
{
    public static class StringExtensions
    {
        public static MarkupString? ToHtmlString(this string s)
        {
            return (MarkupString?) s.Replace("\n", "<br/>")
                .Replace(" ", "&nbsp;");
        }
    }
}