using System;
using Fluxor;

namespace JsonlCompare.Client.Selectors
{
    public class Selector<TSlice, TResult> : ISelector
    {
        private readonly Func<TSlice, TResult> selector;

        private TResult? memoizedResult;
        private int stateHash;

        public Selector(Func<TSlice, TResult> selector)
        {
            this.selector = selector;
        }

        public TResult Select(IState<TSlice> state)
        {
            if (stateHash.Equals(state.GetHashCode()))
                return memoizedResult!;

            memoizedResult = selector(state.Value);
            stateHash = selector.GetHashCode();

            return memoizedResult;
        }
    }
}