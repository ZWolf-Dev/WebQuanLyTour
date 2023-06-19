using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuLich.App_Start;
using DuLich.Models;

namespace DuLich.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DuLichDBEntities db = new DuLichDBEntities();
            //Lấy danh sách tour
            var danhSachTour = db.TourDuLiches.ToList();
            return View(danhSachTour);
        }
        // GET: About
        public ActionResult About()
        {
            return View();
        }
        // GET: Blog
        public ActionResult Blog()
        {
            return View();
        }
        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }
        // GET: Offers
        public ActionResult Offers()
        {
            return View();
        }
        public PartialViewResult TourTotNhat()
        {
            return PartialView();
        }
        public PartialViewResult TourUuDai()
        {
            return PartialView();
        }
        public PartialViewResult Hotel()
        {
            return PartialView();
        }
        public PartialViewResult Search()
        {
            return PartialView();
        }
        public PartialViewResult Slider()
        {
            return PartialView();
        }
        public PartialViewResult CTA()
        {
            return PartialView();
        }
    }
}