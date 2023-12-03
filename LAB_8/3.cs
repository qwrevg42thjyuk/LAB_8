using System;
using System.Collections.Generic;

public class FunctionCache<TKey, TResult>
{
    private Dictionary<TKey, TResult> cache = new Dictionary<TKey, TResult>();
    private Dictionary<TKey, DateTime> cacheTimestamps = new Dictionary<TKey, DateTime>();
    private Func<TKey, TResult> function;
    private TimeSpan cacheDuration;

    public FunctionCache(Func<TKey, TResult> func, TimeSpan duration)
    {
        function = func;
        cacheDuration = duration;
    }

    public TResult GetOrAdd(TKey key)
    {
        if (cache.ContainsKey(key))
        {
            if (DateTime.Now - cacheTimestamps[key] <= cacheDuration)
                return cache[key];
            else
                cache.Remove(key);
        }

        TResult result = function(key);
        cache[key] = result;
        cacheTimestamps[key] = DateTime.Now;
        return result;
    }
}
