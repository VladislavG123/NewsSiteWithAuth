using Newtonsoft.Json;
using SiteNews.DataContext;
using SiteNews.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SiteNews.Areas.News.Controllers
{
    public class HomeController : Controller
    {
        // GET: News/Home
        public ActionResult Index()
        {
            return View("Auth");
        }

        public async Task<string> All()
        {
            using (var context = new NewsContext())
            {
                var data = await context.News.ToListAsync();

                return JsonConvert.SerializeObject(data);
            }
        }

        public ActionResult Auth()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Auth(string login, string password)
        {
            using (var context = new NewsContext())
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Login == login && x.Password == password);
                if (user is null) return View("Auth");
                
                ViewBag.News = context.News.ToList();
                return View("Index");
            }
        }


        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Registration(string login, string email, string password)
        {
            using (var context = new NewsContext())
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Login == login || x.Email == email);
                if (user != null) return View("Registration");

                context.Users.Add(new Models.User { Email = email, Login = login, Password = password });

                await context.SaveChangesAsync();

                ViewBag.News = context.News.ToList();
                return View("Index");
            }
        }

    }
}