using SiteNews.DataContext;
using SiteNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteNews.Areas.AdminPanel.Controllers
{
    public class HomeController : Controller
    {
        // GET: AdminPanel/Home
        private string password = "admin";


        public ActionResult Index()
        {
            return View("Auth");
        }

        [HttpPost]
        public ActionResult Index(string text, HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте
                upload.SaveAs(Server.MapPath("~/Files/" + fileName));

                using (var context = new NewsContext())
                {
                    context.News.Add(new Models.News { Text = text, ImagePath = "Files/" + fileName });
                    context.SaveChanges();
                }

            }
            return View("Index");
        }

        public ActionResult Auth()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Auth(string password)
        {
            if (password == this.password)
                return View("Index");

            else
                return View("Auth");
        }

    }
}