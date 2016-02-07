using MvcApplication.Models;
using MvcApplication.Repository;
using MvcApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class HomeController : BaseController
    {
        IDatabase _database;
        IInvoiceCalculator _invoiceCalculator;
        const int CURRENTPARKINGHOUSE = 1;

        public HomeController(IDatabase dbService, IInvoiceCalculator invoiceCalculator)
        {
            _database = dbService;
            _invoiceCalculator = invoiceCalculator; 
        }

        public ActionResult Index()
        {
            logger.Debug("list parking info");
            var parkingInfos = _database.GetCurrentUserParkingInfo(SessionManager.GetClientID(Session));
            return View(parkingInfos);
        }

        public ActionResult InputData()
        {
            logger.Debug("input test data");
            var clients = _database.GetClientsFromParkingHouse(CURRENTPARKINGHOUSE);
            return View(clients);
        }

        public ActionResult Invoices()
        {
            logger.Debug("list invoices");
            var invoices = _database.GetClientInvoices(SessionManager.GetClientID(Session));
            ViewBag.ShowCreate = _database.GetCurrentUserParkingInfo(SessionManager.GetClientID(Session)).Count > 0;
            return View(invoices);
        }

        public ActionResult InvoiceDetails(int id)
        {
            logger.Debug("invoice details");
            var invoice = _database.GetClientInvoice(id);
            return View(invoice);
        }

        public ActionResult CreateInvoice()
        {
            logger.Debug("create invoice");
            var client = _database.GetClient(SessionManager.GetClientID(Session));
            var parkingInfo = _database.GetCurrentUserParkingInfo(SessionManager.GetClientID(Session));
            var invoice = _invoiceCalculator.CalculateInvoice(client, parkingInfo);
            _database.Save(parkingInfo);
            _database.Save(invoice);
            return Redirect("Invoices");
        }
    }
}