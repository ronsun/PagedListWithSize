using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagedListWithSize.Models.Shared
{
    public class BaseFilters
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 25;
    }
}