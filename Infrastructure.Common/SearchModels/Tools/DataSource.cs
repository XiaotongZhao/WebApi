using System.Collections.Generic;

namespace Infrastructure.Common.SearchModels.Tools
{
    public class DataSource<TSource>
    {
        public List<TSource> Data { get; set; }
        public int Count { get; set; }
    }
}
