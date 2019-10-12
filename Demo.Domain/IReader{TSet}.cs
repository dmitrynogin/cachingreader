using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public interface IReader<TSet>
    {
        Task<TSet> ReadAsync();
    }

    public static class Reader
    {
        public static IReader<TSet> Cache<TSet>(this IReader<TSet> source) =>
            new CachingReader<TSet>(source);
    }

    class CachingReader<TSet> : IReader<TSet>
    {
        public CachingReader(IReader<TSet> source) =>
            Lookup = new Lazy<Task<TSet>>(() => source.ReadAsync());

        Lazy<Task<TSet>> Lookup { get; }
        public Task<TSet> ReadAsync() => Lookup.Value;
    }
}
