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
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [CheckSessionOut]
        public ActionResult Index()
        {
            Dashboard dashborad = new Dashboard();
            return View(dashborad);
        }

        [CheckSessionOut]
        public ActionResult Dashboard()
        {
            DashboardService dashboardService = new DashboardService();
            List<Dashboard> dashboard = new List<Dashboard>();
            dashboard = dashboardService.ViewDashboardData(new Dashboard());

            return View("Dashboard", dashboard);
        }


        [CheckSessionOut]
        public ActionResult DashboardInbox(string EmailBoxID)
        {
            DashboardService dashboardservice = new DashboardService();
            Dashboard dashboard = new Dashboard();
            int emailboxid = Convert.ToInt32(WebHelper.UrlDecode(EmailBoxID, Util.InputType.Number));
            dashboard = dashboardservice.ViewDashboardInboxData(new Dashboard(), emailboxid);
            return View("DashboardInbox", dashboard);
        }


        [CheckSessionOut]
        public ActionResult DashboardCompose()
        {
            DashboardService dashboardservice = new DashboardService();
            Dashboard dashboard = new Dashboard();
            dashboard.UserID = ApplicationManager.LoggedInUser.UserID;
            dashboard = dashboardservice.ViewDashboardComposeData(new Dashboard());
            return View("ComposeDashboard", dashboard);
        }
        
        [HttpPost]
        [CheckSessionOut]
        public ActionResult DashboardCompose(Dashboard dashboard)
        {
            DashboardService dashboardservice = new DashboardService();
            string validationMessage = string.Empty;
            try
            {
                if (ValidatePersonalInfoForm(dashboard, out validationMessage))
                {
                    dashboard.EntityState = EntityState.Save;
                    dashboard.ChangeBy = ApplicationManager.LoggedInUser.UserID;
                    dashboard.UserID = ApplicationManager.LoggedInUser.UserID;

                    dashboard = dashboardservice.ViewDashboardComposeData(dashboard);

                    if (dashboard.responseDetail.responseType == ResponseType.Error)
                    {
                        WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), dashboard.responseDetail.ResponseMessage, "5000");

                        return View("ComposeDashboard", dashboard);
                    }
                    else
                    {
                        WebHelper.SetMessageBoxProperties(this, ResponseType.Success);
                    }
                }
                else
                {
                    WebHelper.SetMessageBoxProperties(this, ResponseType.Error, validationMessage);

                    return View("ComposeDashboard", dashboard);
                }
            }
            catch (Exception ex)
            {
                WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), ApplicationManager.GenericErrorMessage, "5000");
                LoggerHelper.WriteToLog(ex);
            }

            return View("ComposeDashboard", dashboard);
        }

        private bool ValidatePersonalInfoForm(Dashboard dashboard, out string responseMessage)
        {
            bool boolResponse = true;
            responseMessage = "<ul>";

            List<FormData> lsComposeDashboardData = new List<FormData>();

            lsComposeDashboardData.Add(new FormData(FormInputType.Name, dashboard.EmailTo, "EMAILTO", "Email To", true));

            boolResponse = FormValidator.validateForm(lsComposeDashboardData, out responseMessage);
            return boolResponse;
        }


    }
}