using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Surrogacy.Entity;
using Surrogacy.Helper;
using Surrogacy.Models;
using Surrogacy.Service;
using Surrogacy.Util;
using static Surrogacy.Entity.FormData;
using static Surrogacy.MvcApplication;

namespace Surrogacy.Controllers
{
    public class EmailDetailController : Controller
    {
        // GET: EmailDetail
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DashboardInbox(string EmailBoxID)
        {
            DashboardService dashboardservice = new DashboardService();
            Dashboard dashboard = new Dashboard();
            int emailboxid = Convert.ToInt32(WebHelper.UrlDecode(EmailBoxID, Util.InputType.Number));
            dashboard = dashboardservice.ViewDashboardInboxData(new Dashboard(), emailboxid);
            return View("DetailDashboard", dashboard);
        }
    }
}