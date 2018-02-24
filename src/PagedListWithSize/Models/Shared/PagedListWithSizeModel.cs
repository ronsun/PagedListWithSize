using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagedListWithSize.Models.Shared
{
    public class PagedListWithSizeModel
    {
        /// <summary>
        /// Paged data.
        /// </summary>
        public IPagedList Data { get; set; }

        /// <summary>
        ///  Parameter "options" of HtmlHelper.PagedListPager(...).
        /// </summary>
        public PagedListRenderOptions Options { get; set; } = new PagedListRenderOptions();

        /// <summary>
        /// Parameter "generatePageUrl" of HtmlHelper.PagedListPager(...).
        /// </summary>
        public Func<int, string> GeneratePageUrl { get; set; } = (page) => { return "#"; };

        /// <summary>
        /// A function that takes the desired size of page and returns a URL-string
        /// that will load that page.
        /// Almost same with "GeneratePageUrl"
        /// </summary>
        public Func<int, string> GenerateSizeUrl { get; set; } = (size) => { return "#"; };
    }
}