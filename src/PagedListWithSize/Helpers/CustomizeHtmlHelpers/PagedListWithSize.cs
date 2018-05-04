using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PagedListWithSize.Helpers.CustomizeHtmlHelpers
{
    public static class PagedListWithSize
    {
        public static MvcHtmlString PagedListPagerWithSize(this System.Web.Mvc.HtmlHelper helper,
                                                           IPagedList pagedList,
                                                           Func<int, string> generatePageUrl,
                                                           Func<int, string> generateSizeUrl,
                                                           PagedListRenderOptions pageNumberOptions = null,
                                                           PagedListSizeRenderOptions pageSizeOptions = null)
        {
            if (pageNumberOptions == null) pageNumberOptions = new PagedListRenderOptions();
            if (pageSizeOptions == null) pageSizeOptions = new PagedListSizeRenderOptions();

            var pagedListPart = helper.PagedListPager(pagedList, generatePageUrl, pageNumberOptions);

            var pagedSizeListPart = GeneratePageSizeList(pagedList, generateSizeUrl, pageSizeOptions);

            var outerWrapper = new TagBuilder("div");
            outerWrapper.InnerHtml = pagedListPart.ToString() + pagedSizeListPart;

            return new MvcHtmlString(outerWrapper.ToString());
        }

        private static string GeneratePageSizeList(IPagedList pagedList, Func<int, string> generateSizeUrl, PagedListSizeRenderOptions options)
        {
            if(pagedList.TotalItemCount <= 0)
            {
                return string.Empty;
            }

            //header part, will looks like: 
            //  <div class="pagesize-header">Page Size :</div>
            var header = new TagBuilder("div");
            header.AddCssClass("pagesize-header");
            header.SetInnerText(options.HeaderText);

            //paged size list part, will looks like:
            //  <ul class="pagination">
            //    <li class="active"><a href="http://url.com?size=10">10</a></li>
            //    <li class="active"><a href="http://url.com?size=25">14</a></li>
            //  </ul>
            var itemWrapper = new TagBuilder("ul");
            itemWrapper.AddCssClass("pagination");
            itemWrapper.InnerHtml = GenerateSizeItems(pagedList, generateSizeUrl, options);

            //a <div> tage to wrap heaser and size list
            var container = new TagBuilder("div");
            container.AddCssClass("pagesize-container");
            container.InnerHtml = header.ToString() + itemWrapper.ToString();

            return container.ToString();
        }

        private static string GenerateSizeItems(IPagedList pagedList, Func<int, string> generateSizeUrl, PagedListSizeRenderOptions options)
        {
            var itemList = new List<TagBuilder>();
            foreach (var size in options.AllSizes)
            {
                //look like:
                //  <a href="http://sampleurl.com">10</a>
                var a = new TagBuilder("a");
                a.Attributes["href"] = generateSizeUrl(size);
                a.SetInnerText(size.ToString());

                //will looks like
                //  <li class="active"><a href="http://sampleurl.com">10</a></li>
                var li = new TagBuilder("li");
                li.InnerHtml = a.ToString();
                if (pagedList.PageSize == size)
                {
                    li.AddCssClass("active");
                }

                itemList.Add(li);
            }
            string result = itemList.Select(r => r.ToString()).Aggregate((left, right) => left + right);
            return result;
        }
    }
}