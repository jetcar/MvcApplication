using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Services
{
    public class SessionManager
    {
        private const string CLIENTID = "clientId";
        public static int GetClientID(HttpSessionStateBase session)
        {
            return Convert.ToInt32(session[CLIENTID]);
        }
        public static void SetClientId(HttpSessionStateBase session, int id)
        {
            session[CLIENTID] = id;
        }


    }
}