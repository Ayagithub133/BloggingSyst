using BloggingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSystem.Paging
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Pagnate<T> (this IQueryable<T> queryable ,PaginationParameters parameters)
        {
            return queryable.Skip((parameters.PageNumber - 1) * parameters.CountPerPage).Take(parameters.CountPerPage);
        }
    }
}
