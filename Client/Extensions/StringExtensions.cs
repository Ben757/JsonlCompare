using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Components;

namespace JsonlCompare.Client.Extensions
{
    public static class StringExtensions
    {
        public static MarkupString? ToHtmlString(this string s)
        {
            return (MarkupString?) HtmlEncoder.Default.Encode(s)
                .Replace("&#xA;", "<br/>")
                .Replace(" ", "&nbsp;");
        }
    }
}