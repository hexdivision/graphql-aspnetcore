using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PathWays.Common.Utilities
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, int count, int index)
        {
            return query.Skip(index * count).Take(count);
        }

        public static Task<List<T>> ToListAsync<T>(this IEnumerable<T> list)
        {
            return Task.Run(() => list.ToList());
        }
    }
}
