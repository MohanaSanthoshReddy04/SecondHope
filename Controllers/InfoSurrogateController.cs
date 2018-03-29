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
    public class InfoSurrogateController : Controller
    {
        // GET: InfoSurrogate
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult InfoSurrogate(string SurrogateID)
        {
            int localSurrogateID = Convert.ToInt32(WebHelper.UrlDecode(SurrogateID, Util.InputType.Number));
            InfoSurrogateService infosurrogateservice = new InfoSurrogateService();
            InfoSurrogate infosurrogate = new InfoSurrogate();
            infosurrogate = infosurrogateservice.ViewInfoSurrogate(new InfoSurrogate(), localSurrogateID);
            return View("InfoSurrogateDetail", infosurrogate);
        }

        public ActionResult InfoSurrogate(InfoSurrogate infosurrogate)
        {
            int localSurrogateID = Convert.ToInt32(WebHelper.UrlDecode(infosurrogate.SurrogateID, Util.InputType.Number));
            InfoSurrogateService infosurrogateservice = new InfoSurrogateService();
            infosurrogate.UserID = ApplicationManager.LoggedInUser.UserID;
            infosurrogate = infosurrogateservice.ViewInfoSurrogate(new InfoSurrogate(), localSurrogateID);
            return View("InfoSurrogateDetail", infosurrogate);
        }


        [HttpPost]
        public ActionResult SaveInfoSurrogate(InfoSurrogate infosurrogate)
        {
            InfoSurrogateService infosurrogateService = new InfoSurrogateService();
            string validationMessage = string.Empty;

            try
            {

                if (ValidatePersonalInfoForm(infosurrogate, out validationMessage))
                {
                    infosurrogate.EntityState = infosurrogate.DoctorApprovalStatusID != null ? EntityState.Edit : EntityState.Save;
                    infosurrogate.ChangeBy = ApplicationManager.LoggedInUser.UserID;
                    infosurrogate.UserID = ApplicationManager.LoggedInUser.UserID;
                    infosurrogate.SurrogateID = WebHelper.UrlDecode(infosurrogate.SurrogateID, Util.InputType.Number);
                    infosurrogate = infosurrogateService.SaveInfoSurrogate(infosurrogate);

                    if (infosurrogate.responseDetail.responseType == ResponseType.Error)
                    {
                        WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), infosurrogate.responseDetail.ResponseMessage, "5000");

                        return View("InfoSurrogateDetail", infosurrogate);
                    }
                    else
                    {
                        WebHelper.SetMessageBoxProperties(this, ResponseType.Success);

                        return View("InfoSurrogateDetail", infosurrogate);
                    }
                }
                else
                {
                    WebHelper.SetMessageBoxProperties(this, ResponseType.Error, validationMessage);

                    return View("InfoSurrogateDetail", infosurrogate);
                }
            }
            catch (Exception ex)
            {
                WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), ApplicationManager.GenericErrorMessage, "5000");
                LoggerHelper.WriteToLog(ex);

                return View("InfoSurrogateDetail", infosurrogate);
            }
        }

        private bool ValidatePersonalInfoForm(InfoSurrogate infosurrogate, out string responseMessage)
        {
            bool boolResponse = true;
            responseMessage = "<ul>";

            List<FormData> lsinfosurrogate = new List<FormData>();

            lsinfosurrogate.Add(new FormData(FormInputType.DropDownListValue, infosurrogate.ApprovalStatus, "APPROVALSTATUS", "Approval Status", true));
            lsinfosurrogate.Add(new FormData(FormInputType.TextNotEmpty, infosurrogate.Description, "DESCRIPTION", "Description", true));

            boolResponse = FormValidator.validateForm(lsinfosurrogate, out responseMessage);
            return boolResponse;
        }
    }
}