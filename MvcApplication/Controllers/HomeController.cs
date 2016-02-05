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
    public class HomeController : Controller
    {
        IMemoryDatabase _database;
        IInvoiceCalculator _invoiceCalculator;
        const int CURRENTPARKINGHOUSE = 1;

        public HomeController(IMemoryDatabase dbService, IInvoiceCalculator invoiceCalculator)
        {
            _database = dbService;
            _invoiceCalculator = invoiceCalculator; 
        }

        public ActionResult Index()
        {
            var parkingInfos = _database.GetCurrentUserParkingInfo(SessionManager.GetClientID(Session));
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
            var invoices = _database.GetClientInvoices(SessionManager.GetClientID(Session));

            return View(invoices);
        }

        public ActionResult InvoiceDetails(int id)
        {
            var invoice = _database.GetClientInvoice(id);
            return View(invoice);
        }

        public ActionResult CreateInvoice()
        {
            var client = _database.GetClient(SessionManager.GetClientID(Session));
            var invoice = _invoiceCalculator.ClaculateInvoice(client);
            _database.Save(invoice);
            return Redirect("Invoices");
        }
    }
}