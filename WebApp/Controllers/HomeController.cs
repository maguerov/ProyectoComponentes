﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult listado()
        {
            ViewBag.Title = "Listado de reservas";

            return View();
        }

        public ActionResult Registro()
        {
            ViewBag.Title = "Listado de reservas";

            return View();
        }
    }
}
