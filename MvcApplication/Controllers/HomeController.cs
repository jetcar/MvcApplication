﻿using MvcApplication.Models;
using MvcApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        IMemoryDatabase _database;
        const int CURRENTPARKINGHOUSE = 1;

        public HomeController(IMemoryDatabase dbService)
        {
            _database = dbService;
        }

        public ActionResult Index()
        {
            var parkingInfos = _database.GetCurrentUserParkingInfo(1);
            return View(parkingInfos);
        }

        public ActionResult InputData()
        {
            var model = new InputDataViewModel();
            model.Clients = _database.GetClientsFromParkingHouse(CURRENTPARKINGHOUSE);
            return View(model);
        }

        public ActionResult Invoices()
        {
            var invoices = new List<InvoiceModel>();
            return View(invoices);
        }
    }
}