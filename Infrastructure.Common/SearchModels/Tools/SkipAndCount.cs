using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.SearchModels.Tools
{
    public static class SkipAndCount
    {
        public static DataSource<TSource> takePageDataAndCount<TSource>(this IQueryable<TSource> source, int skip, int size)
        {
            DataSource<TSource> result = new DataSource<TSource>();
            result.Data = source.Skip(skip).Take(size).ToList();
            result.Count = source.Count();
            return result; ;
        }

        public static async Task<DataSource<TSource>> takePageDataAndCountAsync<TSource>(this IQueryable<TSource> source, int skip, int size)
        {
            DataSource<TSource> result = new DataSource<TSource>();
            result.Data = await source.Skip(skip).Take(size).ToListAsync();
            result.Count = await source.CountAsync();
            return result; ;
        }
    }
}
