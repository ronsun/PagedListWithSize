using PagedList;

namespace PagedListWithSize.Models.Home
{
    public class SampleVM
    {
        public IPagedList PagedList { get; set; }

        public SampleFilters Filters { get; set; }
    }
}