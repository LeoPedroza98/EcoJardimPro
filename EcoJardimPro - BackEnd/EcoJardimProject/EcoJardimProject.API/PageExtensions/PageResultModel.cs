using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoJardimProject.API.PageExtensions
{
    public class PageResultModel
    {
        public IEnumerable Items { get; }
        public long Count { get; }

        public PageResultModel(IQueryable items, long count)
        {
            Items = items;
            Count = count;
        }

        public PageResultModel(IList items, long count)
        {
            Items = items;
            Count = count;
        }
    }
}