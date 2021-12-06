﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;
using System.Web.Security;

namespace Kutuphane.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBLUYELER p)
        {
            var bilgiler = db.TBLUYELER.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["Mail"] = bilgiler.MAIL.ToString();
                TempData["Ad"] = bilgiler.AD.ToString();
                TempData["Soyad"] = bilgiler.SOYAD.ToString();
                TempData["K.Adi"] = bilgiler.KULLANICIADI.ToString();
                TempData["Sifre"] = bilgiler.SIFRE.ToString();
                TempData["Okul"] = bilgiler.OKUL.ToString();
                return RedirectToAction("Index", "Panelim");
            }
            else
            {
                return View();
            }
            
        }
    }
}