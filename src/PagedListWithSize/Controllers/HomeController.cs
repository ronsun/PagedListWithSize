using PagedList;
using PagedListWithSize.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PagedListWithSize.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SampleOriginal(int? page, int? size)
        {
            ViewBag.PagedList = GetData(page ?? 1, size ?? 25);

            return View();
        }

        public ActionResult SampleByPartialView(SampleFilters filters)
        {
            var model = new SampleVM()
            {
                PagedList = GetData(filters),
                Filters = filters
            };

            return View(model);
        }

        public ActionResult SampleByHtmlHelper(SampleFilters filters)
        {
            var model = new SampleVM()
            {
                PagedList = GetData(filters),
                Filters = filters
            };

            return View(model);
        }

        private IPagedList<string> GetData(int page, int size)
        {
            var data = Enumerable.Range(1, 100).Select(r => $"Data_{r}").ToList();
            return data.ToPagedList(page, size);
        }

        private IPagedList<string> GetData(SampleFilters fitlers)
        {
            var data = Enumerable.Range(1, 5000).Select(r => $"Data_{r}");

            if (!string.IsNullOrEmpty(fitlers.EndWith))
            {
                data = data.Where(r => r.EndsWith(fitlers.EndWith));
            }

            return data.ToPagedList(fitlers.PageNumber, fitlers.PageSize);
        }
    }
}