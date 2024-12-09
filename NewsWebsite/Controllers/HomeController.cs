using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewsWebsite.Models;
using System.Diagnostics;

namespace NewsWebsite.Controllers
{
    public class HomeController : Controller
    {
        NewsDBcontext db;

        public HomeController(NewsDBcontext context)
        {
            db = context;
        }
       // public IActionResult Index()
       // {
          //  var result=dbcontext.Categories.ToList();
           // return View(result);
       // }



      /*  private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public IActionResult Index()
        {
            var result = db.Categories.ToList();
            return View(result);
            
        }
       public IActionResult News(int id)
        {
            if (TempData != null)
            {
                Category c = db.Categories.Find(id);
                //ViewBag.categ = c.Name;
                var result = db.News.Where(x => x.CategoryId == id).OrderByDescending(y => y.Date).ToList();
                return View(result);
            }
            else
                return RedirectToAction("Login", "User");
        }
        public IActionResult DeleteNews(int id)
        {
            var News = db.News.Find(id);
            db.News.Remove(News);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Id");
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create( News news)
        {
           // if (ModelState.IsValid)
            {
                db.News.Add(news);
                 db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", news.CategoryId);
            return View(news);
        }




     //   public IActionResult Privacy()
        //{
            //return View();
       // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
