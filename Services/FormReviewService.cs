using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Surrogacy.Data;
using Surrogacy.Helper;
using Surrogacy.Models;
using Surrogacy.Util;

namespace Surrogacy.Service
{
    public class FormReviewService
    {
        public List<FormReview> ViewFormReviewData(FormReview formreview)
        {
            List<FormReview> localdashboard = new List<FormReview>();
            FormReviewData formreviewdata = new FormReviewData();
            DataSet dataSet = new DataSet();
            FormReview locald = new FormReview();
            locald.UserID = ApplicationManager.LoggedInUser.UserID;
            try
            {
                dataSet = formreviewdata.ViewFormReviewData(locald);

                if (dataSet.Tables["FormReview"].Rows.Count > 0)
                {
                    for (int i = 0; i < dataSet.Tables["FormReview"].Rows.Count; i++)
                    {
                        FormReview lcldash = new FormReview();
                        lcldash.UserID = dataSet.Tables["FormReview"].Rows[i]["USERID"].ToString();
                        lcldash.ID = Convert.ToInt16(dataSet.Tables["FormReview"].Rows[i]["ID"].ToString());
                        lcldash.FormName = dataSet.Tables["FormReview"].Rows[i]["FORMNAME"].ToString();
                        lcldash.ApprovalStatus = dataSet.Tables["FormReview"].Rows[i]["APPROVALSTATUS"].ToString();
                        lcldash.IsSubmitted = dataSet.Tables["FormReview"].Rows[i]["ISSUBMITTED"].ToString();
                        lcldash.Percentage = Convert.ToDecimal(dataSet.Tables["FormReview"].Rows[i]["PERCENTAGE"].ToString());

                        localdashboard.Add(lcldash);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteToLog(ex);
            }

            return localdashboard;
        }
    }
}