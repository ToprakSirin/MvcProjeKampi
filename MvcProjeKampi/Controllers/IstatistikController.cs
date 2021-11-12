using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context context = new Context();
        public ActionResult Index()
        {
            //ViewBag küçük boyuttaki verileri controllerdan view kısmına aktarmak için kullanılır.
            
            var result = context.Categories.Count().ToString();
            ViewBag.deger = result;
            var result2 = context.Headings.Where(p => p.CategoryID == 6).Count();
            ViewBag.deger1 = result2;
            var result3 = context.Writers.Where(p => p.WriterName.Contains("a") || p.WriterName.Contains("A")).Count();
            ViewBag.deger2 = result3;
            var result4 = context.Categories.Where(p => p.CategoryID == context.Headings.GroupBy(x => x.CategoryID).OrderByDescending(x => x.Count())
                 .Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.deger3 = result4;
            var result5 = context.Categories.Where(p => p.CategoryStatus == true).Count();
            var result6 = context.Categories.Where(p => p.CategoryStatus == false).Count();
            var result7 = result5 - result6;
            ViewBag.deger4 = result7;
            return View();
        }
    }
}