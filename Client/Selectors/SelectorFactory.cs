using System;
using System.Collections.Generic;

namespace JsonlCompare.Client.Selectors
{
    public static class SelectorFactory
    {
        private static readonly Dictionary<string, ISelector> Selectors = new();

        public static Selector<TSlice, TResult> CreateSelector<TSlice, TResult>(string identifier, Func<TSlice, TResult> selector)
        {
            if (Selectors.ContainsKey(identifier))
                return (Selector<TSlice, TResult>) Selectors[identifier];
            
            var newSelector = new Selector<TSlice, TResult>(selector);
            Selectors.Add(identifier, newSelector);

            return newSelector;
        }

        public static Selector<TSlice, TResult> GetSelector<TSlice, TResult>(string identifier)
        {
            return (Selector<TSlice, TResult>) Selectors[identifier];
        }
    }
}