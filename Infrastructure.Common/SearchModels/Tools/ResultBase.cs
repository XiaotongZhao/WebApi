using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Common.SearchModels.Tools
{
    internal class ResultBase<T> where T : class
    {
        public List<T> DataList { get; set; }
        public int Count { get; set; }
    }
}
