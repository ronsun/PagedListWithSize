using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagedListWithSize.Models.Home
{
    public class SampleVM
    {
        public IPagedList PagedList { get; set; }

        public SampleFilters Filters { get; set; }
    }
}