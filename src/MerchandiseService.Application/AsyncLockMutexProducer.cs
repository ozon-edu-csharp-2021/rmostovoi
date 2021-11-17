using System.Collections.Concurrent;
using Nito.AsyncEx;

namespace MerchandiseService.Application
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class AsyncLockMutexProducer<TKey> where TKey : notnull
    {
        private static readonly ConcurrentDictionary<TKey, AsyncLock> _mutexes = new();

        public static AsyncLock Get(TKey key) => _mutexes.GetOrAdd(key, _ => new AsyncLock());
    }
}