﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProje.Models.Sınıflar;
namespace TravelTripProje.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin ad)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciAdi == ad.KullaniciAdi && x.Sifre == ad.Sifre);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdi, false);
                Session["Kullanici"] = bilgiler.KullaniciAdi.ToString();
                return RedirectToAction("Index","Admin");
            }
            else
            {
                return View();
            }
            
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","GirisYap");
        }
    }
}