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
using System.IO;

namespace Surrogacy.Controllers
{
    public class SurrogateParentController : Controller
    {
        // GET: SurrogateParent
        public ActionResult Index()
        {
            return View();
        }

        [CheckSessionOut]
        public ActionResult SurrogateParent()
        {
            SurrogateParentService surrogateparentserrvice = new SurrogateParentService();
            
            if(ApplicationManager.LoggedInUser.UserRoleName == "Doctor")
            {
                List<SurrogateParent> surrogateparent = new List<SurrogateParent>();
                surrogateparent = surrogateparentserrvice.ViewSurrogateParentDataList(new SurrogateParent());
                return View("SurrogateParentList", surrogateparent);
            }
            else
            {
                SurrogateParent surrogateparent = new SurrogateParent();
                surrogateparent.UserID = ApplicationManager.LoggedInUser.UserID;
                surrogateparent = surrogateparentserrvice.ViewSurrogateParentData(surrogateparent);
                return View("SurrogateParent", surrogateparent);
            }
            
        }
    }
}