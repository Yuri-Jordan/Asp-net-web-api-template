﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestHelper
{
    public class PagedList<T> : List<T>
    {
        public MetaDataRequest MetaDataRequest { get; set; }

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {

            MetaDataRequest = new MetaDataRequest
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize),
            };

            AddRange(items);
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
