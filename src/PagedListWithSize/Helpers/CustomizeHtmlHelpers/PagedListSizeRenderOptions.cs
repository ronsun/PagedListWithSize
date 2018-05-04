using System.Collections.Generic;

namespace PagedListWithSize.Helpers.CustomizeHtmlHelpers
{
    public class PagedListSizeRenderOptions
    {
        public List<int> AllSizes { get; set; } = new List<int>() { 10, 25, 50, 100 };

        public string HeaderText { get; set; } = "Page Size: ";
    }
}