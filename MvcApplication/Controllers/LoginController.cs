using MvcApplication.Repository;
using MvcApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class LoginController : BaseController
    {
        private int CURRENTPARKINGHOUSE = 1;
        private IMemoryDatabase _database;

        public LoginController(IMemoryDatabase database)
        {

            _database = database;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View(_database.GetClientsFromParkingHouse(CURRENTPARKINGHOUSE));
        }

        public ActionResult Login(int clientId)
        {
            logger.DebugFormat("Login as {0}",clientId);

            SessionManager.SetClientId(Session, clientId);
            return RedirectToAction("Index", "Home");
        }
    }
}