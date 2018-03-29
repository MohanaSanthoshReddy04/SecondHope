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
    public class DashboardService
    {
        public List<Dashboard> ViewDashboardData(Dashboard dashboard)
        {
            List<Dashboard> localdashboard = new List<Dashboard>();
            DashboardData dashboarddata = new DashboardData();
            DataSet dataSet = new DataSet();
            Dashboard locald = new Dashboard();
            locald.UserID = ApplicationManager.LoggedInUser.UserID;
            locald.FolderType = "Inbox";
            try
            {
                dataSet = dashboarddata.ViewDashboardData(locald);

                if (dataSet.Tables["Dashboard"].Rows.Count > 0)
                {
                    for (int i = 0; i < dataSet.Tables["Dashboard"].Rows.Count; i++)
                    {
                        Dashboard lcldash = new Dashboard();
                        lcldash.UserID = dataSet.Tables["Dashboard"].Rows[i]["USERID"].ToString();
                        lcldash.EmailBoxID = Convert.ToInt16(dataSet.Tables["Dashboard"].Rows[i]["EMAILBOXID"].ToString());
                        lcldash.UserRoleDetail = dataSet.Tables["Dashboard"].Rows[i]["USERROLE"].ToString();
                        lcldash.FolderType = dataSet.Tables["Dashboard"].Rows[i]["FOLDERTYPE"].ToString();
                        lcldash.EmailFrom = dataSet.Tables["Dashboard"].Rows[i]["EMAILFROM"].ToString();
                        lcldash.EmailTo = dataSet.Tables["Dashboard"].Rows[i]["EMAILTO"].ToString();
                        lcldash.EmailCC = dataSet.Tables["Dashboard"].Rows[i]["EMAILCC"].ToString();
                        lcldash.EmailBCC = dataSet.Tables["Dashboard"].Rows[i]["EMAILBCC"].ToString();
                        lcldash.EmailSubject = dataSet.Tables["Dashboard"].Rows[i]["EMAILSUBJECT"].ToString();
                        lcldash.EmailBody = dataSet.Tables["Dashboard"].Rows[i]["EMAILBODY"].ToString();
                        lcldash.IsRead = Convert.ToInt16(dataSet.Tables["Dashboard"].Rows[i]["ISREAD"].ToString());
                        lcldash.ReceivedTime = dataSet.Tables["Dashboard"].Rows[i]["RECEIVEDTIME"].ToString();
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

        public Dashboard ViewDashboardInboxData(Dashboard dashboard,int EmailBoxID)
        {
            DashboardData dashboarddata = new DashboardData();
            DataSet dataSet = new DataSet();
            Dashboard lcldash = new Dashboard();
            lcldash.UserID = ApplicationManager.LoggedInUser.UserID;
            lcldash.FolderType = "Inbox";
            lcldash.EmailBoxID = EmailBoxID;
            try
            {
                dataSet = dashboarddata.ViewDashboardData(lcldash);

                if (dataSet.Tables["Dashboard"].Rows.Count > 0)
                {
                        lcldash.UserID = dataSet.Tables["Dashboard"].Rows[0]["USERID"].ToString();
                        lcldash.EmailBoxID = Convert.ToInt16(dataSet.Tables["Dashboard"].Rows[0]["EMAILBOXID"].ToString());
                        lcldash.UserRoleDetail = dataSet.Tables["Dashboard"].Rows[0]["USERROLE"].ToString();
                        lcldash.FolderType = dataSet.Tables["Dashboard"].Rows[0]["FOLDERTYPE"].ToString();
                        lcldash.EmailFrom = dataSet.Tables["Dashboard"].Rows[0]["EMAILFROM"].ToString();
                        lcldash.EmailTo = dataSet.Tables["Dashboard"].Rows[0]["EMAILTO"].ToString();
                        lcldash.EmailCC = dataSet.Tables["Dashboard"].Rows[0]["EMAILCC"].ToString();
                        lcldash.EmailBCC = dataSet.Tables["Dashboard"].Rows[0]["EMAILBCC"].ToString();
                        lcldash.EmailSubject = dataSet.Tables["Dashboard"].Rows[0]["EMAILSUBJECT"].ToString();
                        lcldash.EmailBody = dataSet.Tables["Dashboard"].Rows[0]["EMAILBODY"].ToString();
                        lcldash.IsRead = Convert.ToInt16(dataSet.Tables["Dashboard"].Rows[0]["ISREAD"].ToString());
                        lcldash.ReceivedTime = dataSet.Tables["Dashboard"].Rows[0]["RECEIVEDTIME"].ToString();
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteToLog(ex);
            }

            return lcldash;
        }

        public Dashboard ViewDashboardComposeData(Dashboard dashboard)
        {
            DashboardData dashboarddata = new DashboardData();
            DataSet dataSet = new DataSet();
            Dashboard lcldash = new Dashboard();
            lcldash.UserID = ApplicationManager.LoggedInUser.UserID;
            try
            {
                dataSet = dashboarddata.ViewDashboardComposeData(lcldash);

                if (dataSet.Tables["Dashboard"].Rows.Count > 0)
                {
                    lcldash.UserID = dataSet.Tables["Dashboard"].Rows[0]["USERID"].ToString();
                    lcldash.EmailBoxID = Convert.ToInt16(dataSet.Tables["Dashboard"].Rows[0]["EMAILBOXID"].ToString());
                    lcldash.UserRoleDetail = dataSet.Tables["Dashboard"].Rows[0]["USERROLE"].ToString();
                    lcldash.FolderType = dataSet.Tables["Dashboard"].Rows[0]["FOLDERTYPE"].ToString();
                    lcldash.EmailFrom = dataSet.Tables["Dashboard"].Rows[0]["EMAILFROM"].ToString();
                    lcldash.EmailTo = dataSet.Tables["Dashboard"].Rows[0]["EMAILTO"].ToString();
                    lcldash.EmailCC = dataSet.Tables["Dashboard"].Rows[0]["EMAILCC"].ToString();
                    lcldash.EmailBCC = dataSet.Tables["Dashboard"].Rows[0]["EMAILBCC"].ToString();
                    lcldash.EmailSubject = dataSet.Tables["Dashboard"].Rows[0]["EMAILSUBJECT"].ToString();
                    lcldash.EmailBody = dataSet.Tables["Dashboard"].Rows[0]["EMAILBODY"].ToString();
                    lcldash.IsRead = Convert.ToInt16(dataSet.Tables["Dashboard"].Rows[0]["ISREAD"].ToString());
                    lcldash.ReceivedTime = dataSet.Tables["Dashboard"].Rows[0]["RECEIVEDTIME"].ToString();
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteToLog(ex);
            }

            return lcldash;
        }
    }
       
}