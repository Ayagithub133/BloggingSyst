using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSystem.Paging
{
    public static class HttpContextExtensions
    {
       
            public static async Task INsertPaginationParametersInResponse<T>
                (this HttpContext httpContext, IQueryable<T> queryable, int recordsPage)
            {
                double count = await queryable.CountAsync();
                double pagesQuantity = Math.Ceiling(count / recordsPage);
                httpContext.Response.Headers.Add("pagesQuantity", pagesQuantity.ToString());

            }
        

    }
}
