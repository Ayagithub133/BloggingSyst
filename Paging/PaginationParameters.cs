using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSystem.Paging
{
    public class PaginationParameters
    {
        public int PageNumber { set; get; } = 1;
        public int CountPerPage { set; get; } = 10;
        public string CategoryId { set; get; }
    }
}
