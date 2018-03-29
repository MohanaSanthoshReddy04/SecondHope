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
    public class FormReviewController : Controller
    {
        [CheckSessionOut]
        public ActionResult Index()
        {
            FormReview formreview = new FormReview();
            return View(formreview);
        }

        [CheckSessionOut]
        public ActionResult FormReview()
        {
            FormReviewService formreviewservice = new FormReviewService();
            List<FormReview> formreview = new List<FormReview>();
            formreview = formreviewservice.ViewFormReviewData(new FormReview());

            return View("FormReview", formreview);
        }
    }
}